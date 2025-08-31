using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.UI.Controllers
{
    public class DashboardController(
        IBrandService brandService,
        ICategoryService categoryService,
        IContactService contactService,
        IProductService productService,
        IActionLogService actionLogService
        ) : Controller
    {
        public IActionResult Index()
        {
            TempData["NotSuperAdmin"] = false;
        var role = HttpContext.Session.GetString("UserRole");


        if (role != "SuperAdmin")
        {
            TempData["NotSuperAdmin"] = true;
            //TempData["ErrorMessage"] = "Bu sayfaya sadece SuperAdmin erişebilir.";
        }


            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.BrandCount = brandService.TGetListAll().Count;
            ViewBag.CategoryCount = categoryService.TGetListAll().Count;
            ViewBag.ContactCount = contactService.TGetListAll().Count;
            ViewBag.ProductCount = productService.TGetListAll().Count;
            ViewBag.ActionLogCount = actionLogService.TGetListAll();


            return View();
        }
    }
}
