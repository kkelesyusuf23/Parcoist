using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcoist.Business.Abstract;
using Parcoist.DTO.ProductVariantValueDtos;
using Parcoist.UI.Entities;

namespace Parcoist.UI.Controllers
{
    public class ProductVariantValueController : Controller
    {
        private readonly IProductVariantCombinationService _productVariantCombinationService;
        private readonly IFeatureTypeService _featureTypeService;
        private readonly IFeatureValueService _featureValueService;
        private readonly IProductVariantValueService _productVariantValueService;

        public ProductVariantValueController(
            IProductVariantCombinationService productVariantCombinationService,
            IFeatureTypeService featureTypeService,
            IFeatureValueService featureValueService,
            IProductVariantValueService productVariantValueService)
        {
            _productVariantCombinationService = productVariantCombinationService;
            _featureTypeService = featureTypeService;
            _featureValueService = featureValueService;
            _productVariantValueService = productVariantValueService;
        }

        public IActionResult Index()
        {
            var values = _productVariantValueService.TGetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Combinations = new SelectList(_productVariantCombinationService.TGetListAll(), "ProductVariantCombinationID", "VariantKey");
            ViewBag.FeatureTypes = new SelectList(_featureTypeService.TGetListAll(), "FeatureTypeID", "Value");
            ViewBag.FeatureValues = new SelectList(_featureValueService.TGetListAll(), "FeatureValueID", "Value");
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateProductVariantValueDto dto)
        {
            var productVariantValue = new ProductVariantValue
            {
                CombinationID = dto.CombinationID,
                FeatureTypeID = dto.FeatureTypeID,
                FeatureValueID = dto.FeatureValueID,
            };
            _productVariantValueService.TAdd(productVariantValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _productVariantValueService.TGetById(id);
            ViewBag.Combinations = new SelectList(_productVariantCombinationService.TGetListAll(), "ProductVariantCombinationID", "VariantKey", value.CombinationID);
            ViewBag.FeatureTypes = new SelectList(_featureTypeService.TGetListAll(), "FeatureTypeID", "Value", value.FeatureTypeID);
            ViewBag.FeatureValues = new SelectList(_featureValueService.TGetListAll(), "FeatureValueID", "Value", value.FeatureValueID);
            var dto = new UpdateProductVariantValueDto
            {
                ProductVariantValueID = value.ProductVariantValueID,
                CombinationID = value.CombinationID,
                FeatureTypeID = value.FeatureTypeID,
                FeatureValueID = value.FeatureValueID
            };
            return View(dto);
        }

        [HttpPost]
        public IActionResult Update(UpdateProductVariantValueDto dto)
        {
            var productVariantValue = _productVariantValueService.TGetById(dto.ProductVariantValueID);
            if (productVariantValue == null)
            {
                return View();
            }
            productVariantValue.CombinationID = dto.CombinationID;
            productVariantValue.FeatureTypeID = dto.FeatureTypeID;
            productVariantValue.FeatureValueID = dto.FeatureValueID;
            _productVariantValueService.TUpdate(productVariantValue);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var value = _productVariantValueService.TGetById(id);

            _productVariantValueService.TUpdate(value);
            return View(value);
        }

        public IActionResult Remove(int id)
        {
            var value = _productVariantValueService.TGetById(id);
            if (value != null)
            {
                _productVariantValueService.TDelete(value);
            }
            return RedirectToAction("Index");

        }
    }
}