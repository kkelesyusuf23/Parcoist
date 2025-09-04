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
        IActionLogService actionLogService,
        IProductCommentService userCommentService,
        IUserService userService
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

            ViewBag.BrandCount = brandService.TGetListAll().Where(x=>x.IsActive).ToList().Count;
            ViewBag.CategoryCount = categoryService.TGetListAll().Where(x => x.IsActive).ToList().Count;
            ViewBag.ProductCount = productService.TGetProductsWithAllRelations().Where(x => x.IsActive).ToList().Count;
            ViewBag.CommentCount = userCommentService.TGetListAll().Where(x => x.IsActive).ToList().Count;

            //ViewBag.ContactCount = contactService.TGetListAll().Count;
            //ViewBag.UserCount = userService.TGetListAll().Count;
            //ViewBag.ActionCount = actionLogService.TGetListAll().Count;

            //ViewBag.ActionLogs = actionLogService.TGetListAll();
            ViewBag.Messages = contactService.TGetListAll().Where(x => x.ContactStatus).ToList();
            ViewBag.UserComments = userCommentService.TGetListAll().Where(x => x.IsActive).ToList();


            return View();
        }
    }
}
