using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.UI.Controllers
{
    public class FeatureValueController : Controller
    {
        private readonly IFeatureValueService _featureValueService;
        public FeatureValueController(IFeatureValueService featureValueService)
        {
            _featureValueService = featureValueService;
        }
        public IActionResult Index()
        {
            var featureValues = _featureValueService.TGetListAll();
            return View(featureValues);
        }


    }
}
