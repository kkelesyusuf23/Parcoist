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
            var featureTypes = _featureTypeCategoryService.TGetListAll();
            return View(featureTypes);
        }


    }
}
