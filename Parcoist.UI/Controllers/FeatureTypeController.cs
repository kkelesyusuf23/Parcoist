using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.DTO.FeatureTypeDtos;
using Parcoist.UI.Entities;

namespace Parcoist.UI.Controllers
{
    public class FeatureTypeController : Controller
    {
        private readonly IFeatureTypeService _featureTypeService;

        public FeatureTypeController(IFeatureTypeService featureTypeService)
        {
            _featureTypeService = featureTypeService;
        }

        public IActionResult Index()
        {
            var featureTypes = _featureTypeService.TGetListAll();
            return View(featureTypes);
        }

        public IActionResult Delete(int id)
        {
            var value = _featureTypeService.TGetById(id);
            _featureTypeService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var value = _featureTypeService.TGetById(id);
            if (value != null)
            {
                _featureTypeService.TDelete(value);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreateFeatureTypeDto featureType)
        {
            if (ModelState.IsValid)
            {
                var newFeatureType = new FeatureType
                {
                    Value = featureType.Value,
                    PriceAdjustment = featureType.PriceAdjustment,
                    IsDefault = false,
                    UpdatetAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                };
                _featureTypeService.TAdd(newFeatureType);
                return RedirectToAction("Index");
            }
            return View(featureType);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var featureType = _featureTypeService.TGetById(id);
            if (featureType == null)
            {
                return View();
            }
            var updateFeatureTypeDto = new UpdateFeatureTypeDto
            {
                FeatureTypeID = featureType.FeatureTypeID,
                Value = featureType.Value,
                PriceAdjustment = featureType.PriceAdjustment,
            };
            return View(updateFeatureTypeDto);
        }
        [HttpPost]
        public IActionResult Update(UpdateFeatureTypeDto featureType)
        {
            if (ModelState.IsValid)
            {
                var updatedFeatureType = new FeatureType
                {
                    FeatureTypeID = featureType.FeatureTypeID,
                    Value = featureType.Value,
                    PriceAdjustment = featureType.PriceAdjustment,
                    UpdatetAt = DateTime.Now,
                };
                _featureTypeService.TUpdate(updatedFeatureType);
                return RedirectToAction("Index");
            }
            return View(featureType);
        }
    }
}
