using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.UI.Controllers
{
    public class BrandCategoryController : Controller
    {
        private readonly IBrandCategoryService _brandCategoryService;

        public BrandCategoryController(IBrandCategoryService brandCategoryService)
        {
            _brandCategoryService = brandCategoryService;
        }

        public IActionResult Index()
        {
            // Kullanıcı giriş yapmış mı kontrol et
            var userId = HttpContext.Session.GetInt32("UserID");

            if (userId == null)
            {
                // Giriş yapılmamışsa login sayfasına yönlendir
                return RedirectToAction("Login", "Auth");
            }
            var brandCategories = _brandCategoryService.TGetListAll();
            return View(brandCategories);
        }

    }
}
