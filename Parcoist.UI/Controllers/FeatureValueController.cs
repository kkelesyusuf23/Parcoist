using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcoist.Business.Abstract;
using Parcoist.DTO.FeatureValueDtos;
using Parcoist.Entity.Concrete;

namespace Parcoist.UI.Controllers
{
    public class FeatureValueController : Controller
    {
        private readonly IFeatureValueService _featureValueService;
        private readonly IFeatureTypeService _featureTypeService;
        public FeatureValueController(IFeatureValueService featureValueService, IFeatureTypeService featureTypeService)
        {
            _featureValueService = featureValueService;
            _featureTypeService = featureTypeService;
        }
        public IActionResult Index()
        {
            var featureValues = _featureValueService.TGetListAll();
            if (featureValues == null || !featureValues.Any())
            {
                return View(); 
            }
            return View(featureValues);
        }

        public IActionResult Delete(int id)
        {
            var value = _featureValueService.TGetById(id);
            _featureValueService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var value = _featureValueService.TGetById(id);
            if (value != null)
            {
                _featureValueService.TDelete(value);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Add()
        {
            var featureTypes = _featureTypeService.TGetListAll();
            ViewBag.FeatureTypes = new SelectList(featureTypes, "FeatureTypeID", "Value");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateFeatureValueDto dto)
        {
            

            FeatureValue featureValue = new FeatureValue()
            {
                FeatureTypeID = dto.FeatureTypeID,
                Value = dto.Value,
                UpdatedAt = DateTime.Now,
                PriceAdjustment = dto.PriceAdjustment,
                Stock = dto.Stock,
                CreatedAt = DateTime.Now
            };
            _featureValueService.TAdd(featureValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var contact = _featureValueService.TGetById(id);
            if (contact == null) return View();
            var featureTypes = _featureTypeService.TGetListAll();
            ViewBag.FeatureTypes = new SelectList(featureTypes, "FeatureTypeID", "Value");
            var dto = new UpdateFeatureValueDto
            {
                FeatureValueID = contact.FeatureValueID,
                FeatureTypeID = contact.FeatureTypeID,
                Value = contact.Value,
                PriceAdjustment = contact.PriceAdjustment,
                Stock = contact.Stock
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Update(UpdateFeatureValueDto dto)
        {
            if (ModelState.IsValid)
            {
                var featureValue = new FeatureValue
                {
                    FeatureValueID = dto.FeatureValueID,
                    FeatureTypeID = dto.FeatureTypeID,
                    Value = dto.Value,
                    PriceAdjustment = dto.PriceAdjustment,
                    Stock = dto.Stock,
                    UpdatedAt = DateTime.Now
                };
                _featureValueService.TUpdate(featureValue);
                return RedirectToAction("Index");
            }
            return View(dto);
        }
    }
}
