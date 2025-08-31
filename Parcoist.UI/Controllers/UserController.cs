using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcoist.DataAccess.Concrete;
using Parcoist.UI.Entities;
using Parcoist.UI.Models;

public class UserController : Controller
{
    private readonly ParcoContext _context;

    public UserController(ParcoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult AddUser()
    {
        TempData["NotSuperAdmin"] = false;
        var role = HttpContext.Session.GetString("UserRole");

        if (string.IsNullOrEmpty(role))
        {
            // Login olmamış
            return RedirectToAction("Login", "Auth");
        }

        if (role != "SuperAdmin")
        {
            TempData["NotSuperAdmin"] = true;
            //TempData["ErrorMessage"] = "Bu sayfaya sadece SuperAdmin erişebilir.";
            return RedirectToAction("Index", "Home");
        }
        ViewBag.Roles = _context.Roles.Where(r => r.IsActive).ToList();

        return View(new AddUserViewModel());
    }

    [HttpPost]
    public IActionResult AddUser(AddUserViewModel model)
    {
        var role = HttpContext.Session.GetString("UserRole");
        if (role != "SuperAdmin")
        {
            ModelState.AddModelError("", "Sadece SuperAdmin kullanıcı ekleyebilir.");
            return RedirectToAction("Login", "Auth");
        }
        if (!ModelState.IsValid)
        {
            ViewBag.Roles = _context.Roles.Where(r => r.IsActive).ToList();
            return View(model);
        }

        // Şifreleme
        PasswordHelper.CreatePasswordHash(model.Password, out string hash, out string salt);

        var user = new User
        {
            Name = model.Name,
            Surname = model.Surname,
            Email = model.Email,
            PasswordHash = hash,
            PasswordSalt = salt,
            RoleID = model.RoleID,
            IsActive = true,
            IsEmailConfirmed = true,
            CreatedAt = DateTime.Now,
            EmailConfirmationToken="null"
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        // Admin kaydı
        _context.Admins.Add(new Admin
        {
            UserID = user.UserID,
            IsActive = true,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        });
        _context.SaveChanges();

        TempData["Success"] = "Kullanıcı başarıyla eklendi.";
        return RedirectToAction("AddUser");
    }


    [HttpGet]
    public IActionResult Users()
    {
        TempData["NotSuperAdmin"] = false;
        var role = HttpContext.Session.GetString("UserRole");


        if (role != "SuperAdmin")
        {
            TempData["NotSuperAdmin"] = true;
            //TempData["ErrorMessage"] = "Bu sayfaya sadece SuperAdmin erişebilir.";
        }
        var users = _context.Users.Include(u => u.Role).ToList();
        return View(users);
    }
    [HttpGet]
    public IActionResult EditUser(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.UserID == id);
        if (user == null) return RedirectToAction("Login","Auth");

        ViewBag.Roles = _context.Roles.Where(r => r.IsActive).ToList();

        var model = new UpdateUserViewModel
        {
            UserID = user.UserID,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            Phone = user.Phone,
            BirthDate = user.BirthDate,
            RoleID = user.RoleID,
            IsActive = user.IsActive
        };

        return View(model);
    }
    [HttpPost]
    public IActionResult EditUser(UpdateUserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Roles = _context.Roles.Where(r => r.IsActive).ToList();
            return View(model);
        }

        var user = _context.Users.FirstOrDefault(u => u.UserID == model.UserID);
        if (user == null) return RedirectToAction("Login","Auth");

        user.Name = model.Name;
        user.Surname = model.Surname;
        user.Email = model.Email;
        user.Phone = model.Phone;
        user.BirthDate = model.BirthDate;
        user.RoleID = model.RoleID;
        user.IsActive = model.IsActive;
        user.UpdatedAt = DateTime.Now;

        _context.SaveChanges();

        TempData["Success"] = "Kullanıcı başarıyla güncellendi.";
        return RedirectToAction("Users");
    }
}
