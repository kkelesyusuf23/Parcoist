using Microsoft.AspNetCore.Mvc;
using Parcoist.UI.Entities;
using Parcoist.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;

public class AuthController : Controller
{
    private readonly ParcoContext _context;

    public AuthController(ParcoContext context)
    {
        _context = context;
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = _context.Users
    .Include(u => u.Admin)
    .Include(u => u.Role)   
    .FirstOrDefault(u => u.Email == email && u.IsActive);
        if (user == null || user.Admin == null)
        {
            ModelState.AddModelError("", "Geçersiz kullanıcı veya yetkisiz giriş.");
            return View();
        }

        if (!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            ModelState.AddModelError("", "Şifre yanlış.");
            return View();
        }

        HttpContext.Session.SetInt32("UserID", user.UserID);
        HttpContext.Session.SetString("UserRole", user.Role.RoleName);
        TempData["WelcomeMessage"] = $"Hoşgeldin,  {user.Name} {user.Surname}!";

        return RedirectToAction("Index", "Dashboard");
    }

    public IActionResult Logout()
    {
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
    public IActionResult ChangePassword() => View();

    [HttpPost]
    public IActionResult ChangePassword(string oldPassword, string newPassword)
    {
        int? userId = HttpContext.Session.GetInt32("UserID");
        if (userId == null) return Unauthorized();

        var user = _context.Users.FirstOrDefault(u => u.UserID == userId);
        if (user == null || user.Role.RoleName != "SuperAdmin") return Unauthorized();

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
