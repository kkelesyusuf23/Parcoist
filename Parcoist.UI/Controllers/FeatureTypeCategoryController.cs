using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.UI.Controllers
{
    public class FeatureTypeCategoryController : Controller
    {
        private readonly IFeatureTypeCategoryService _featureTypeCategoryService;

        public FeatureTypeCategoryController(IFeatureTypeCategoryService featureTypeCategoryService)
        {
            _featureTypeCategoryService = featureTypeCategoryService;
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
            var featureTypes = _featureTypeCategoryService.TGetListAll();
            return View(featureTypes);
        }


    }
}
