using Microsoft.AspNetCore.Mvc;
using Parcoist.UI.Entities;
using Parcoist.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Parcoist.UI.Helpers;
using Parcoist.Business.Abstract;
using Microsoft.EntityFrameworkCore.Storage;

public class AuthController : Controller
{
    private readonly ParcoContext _context;
    private readonly IActionLogService _actionLogService;

    public AuthController(ParcoContext context, IActionLogService actionLogService)
    {
        _context = context;
        _actionLogService = actionLogService;
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        // Kullanıcıyı email ve aktiflik durumuna göre getir
        var user = _context.Users
            .Include(u => u.Admin)
            .Include(u => u.Role)
            .FirstOrDefault(u => u.Email == email && u.IsActive);

        // Kullanıcı veya Admin bilgisi yoksa
        if (user == null || user.Admin == null)
        {
            ModelState.AddModelError("", "Geçersiz kullanıcı veya yetkisiz giriş.");
            return View();
        }

        // Şifre doğrulama
        if (!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            ModelState.AddModelError("", "Şifre yanlış.");
            return View();
        }

        // Session bilgilerini ayarla
        HttpContext.Session.SetInt32("UserID", user.UserID);
        HttpContext.Session.SetString("UserFullName", $"{user.Name} {user.Surname}");
        HttpContext.Session.SetString("UserRole", user.Role.RoleName);

        // SuperAdmin kontrolü
        bool isSuperAdmin = user.Role.RoleName == "SuperAdmin";
        HttpContext.Session.SetString("IsSuperAdmin", isSuperAdmin.ToString().ToLower()); // "true" / "false"

        // Hoş geldin mesajı
        TempData["WelcomeMessage"] = $"Hoşgeldin, {user.Name} {user.Surname}!";

        // Aksiyon logu
        ActionLogHelper.LogAction(_actionLogService, "Login", user.Name, user.UserID);

        // Dashboard'a yönlendir
        return RedirectToAction("Index", "Dashboard");
    }


    public IActionResult Logout()
    {
        int? userId = HttpContext.Session.GetInt32("UserID");
        var user = _context.Users.FirstOrDefault(u => u.UserID == userId);
        var message = user != null ? $"{user.Name} {user.Surname} çıkış yaptı." : "Bilinmeyen kullanıcı çıkış yaptı.";
        ActionLogHelper.LogAction(_actionLogService, "Logout", message, userId);
        HttpContext.Session.Clear();
        
        return RedirectToAction("Login");
    }

    //[HttpGet]
    //public IActionResult Register() => View();

    //[HttpPost]
    //public IActionResult Register(string name, string surname, string email, string password, string roleName)
    //{
    //    var currentRole = HttpContext.Session.GetString("Role");
    //    if (currentRole != "SuperAdmin") return Unauthorized("Sadece SuperAdmin yeni admin ekleyebilir.");

    //    var role = _context.Roles.FirstOrDefault(r => r.RoleName == roleName);
    //    if (role == null) return BadRequest("Role bulunamadı.");

    //    PasswordHelper.CreatePasswordHash(password, out string hash, out string salt);

    //    var user = new User
    //    {
    //        Name = name,
    //        Surname = surname,
    //        Email = email,
    //        PasswordHash = hash,
    //        PasswordSalt = salt,
    //        RoleID = role.RoleID,
    //        IsActive = true,
    //        IsEmailConfirmed = true,
    //        CreatedAt = DateTime.Now
    //    };

    //    _context.Users.Add(user);
    //    _context.SaveChanges();

    //    _context.Admins.Add(new Admin
    //    {
    //        UserID = user.UserID,
    //        IsActive = true,
    //        CreatedAt = DateTime.Now,
    //        UpdatedAt = DateTime.Now
    //    });
    //    _context.SaveChanges();

    //    return RedirectToAction("Login");
    //}

    [HttpGet]
    public IActionResult ChangePassword()
    {
        int? userId = HttpContext.Session.GetInt32("UserID");
        if (userId == null)
        {
            return RedirectToAction("Login");
        }
        return View();
    }

    [HttpPost]
    public IActionResult ChangePassword(string oldPassword, string newPassword)
    {
        int? userId = HttpContext.Session.GetInt32("UserID");
        if (userId == null) return RedirectToAction("Login");

        var user = _context.Users.FirstOrDefault(u => u.UserID == userId);
        //if (user == null || user.Role.RoleName != "SuperAdmin") return Unauthorized();

        if (!PasswordHelper.VerifyPasswordHash(oldPassword, user.PasswordHash, user.PasswordSalt))
        {
            ModelState.AddModelError("", "Mevcut şifre yanlış.");
            return View();
        }

        PasswordHelper.CreatePasswordHash(newPassword, out string hash, out string salt);
        user.PasswordHash = hash;
        user.PasswordSalt = salt;
        _context.SaveChanges();

        return RedirectToAction("Login");
    }


    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View(); //404 sayfasını yapmam gerek
    }
}
