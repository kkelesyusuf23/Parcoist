using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcoist.Business.Abstract;
using Parcoist.DTO.ProductImage;
using Parcoist.DTO.ProductVariantCombinationDtos;
using Parcoist.Entity.Concrete;
using Parcoist.UI.Entities;

namespace Parcoist.UI.Controllers
{
    public class ProductVariantCombinationController : Controller
    {
        private readonly IProductVariantCombinationService _productVariantCombinationService;
        private readonly IProductService _productService;

        public ProductVariantCombinationController(IProductVariantCombinationService productVariantCombinationService, IProductService productService)
        {
            _productVariantCombinationService = productVariantCombinationService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var productImages = _productVariantCombinationService.TGetListAll();
            return View(productImages);
        }

        public IActionResult Delete(int id)
        {
            var value = _productVariantCombinationService.TGetById(id);
            //value.IsActive = false;
            _productVariantCombinationService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var value = _productVariantCombinationService.TGetById(id);
            if (value != null)
            {
                _productVariantCombinationService.TDelete(value);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var parentProduct = _productService.TGetListAll();
            ViewBag.ParentProduct = new SelectList(parentProduct, "ProductID", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductVariantCombinationDto dto)
        {


            ProductVariantCombination productImage = new ProductVariantCombination
            {
                ProductID = dto.ProductID,
                VariantKey = dto.VariantKey,
                Stock = dto.Stock,
                PriceAdjustment = dto.PriceAdjustment,
                CreatedAt = DateTime.Now,
                isDefault = false
            };
            _productVariantCombinationService.TAdd(productImage);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _productVariantCombinationService.TGetById(id);

            var dto = new UpdateProductVariantCombinationDto
            {
                ProductVariantCombinationID = value.ProductVariantCombinationID,
                ProductID = value.ProductID,
                VariantKey = value.VariantKey,
                Stock = value.Stock,
                PriceAdjustment = value.PriceAdjustment,
                isDefault = value.isDefault
            };

            var parentProduct = _productService.TGetListAll();
            ViewBag.ParentProduct = new SelectList(parentProduct, "ProductID", "Name");
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVariantCombinationDto p)
        {
            var existingCombination = _productVariantCombinationService.TGetById(p.ProductVariantCombinationID);
            if (existingCombination == null)
            {
                return View();
            }
            existingCombination.ProductID = p.ProductID;
            existingCombination.VariantKey = p.VariantKey;
            existingCombination.Stock = p.Stock;
            existingCombination.PriceAdjustment = p.PriceAdjustment;
            existingCombination.isDefault = p.isDefault;
            _productVariantCombinationService.TUpdate(existingCombination);
            return RedirectToAction("Index");
        }
    }
}
