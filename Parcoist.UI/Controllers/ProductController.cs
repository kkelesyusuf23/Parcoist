using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcoist.Business.Abstract;
using Parcoist.DTO.ProductDtos;
using Parcoist.UI.Entities;

namespace Parcoist.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;

        public ProductController(IWebHostEnvironment webHostEnvironment, IProductService productService, IBrandService brandService, ICategoryService categoryService)
        {
            _webHostEnvironment = webHostEnvironment;
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var products = _productService.TGetListAll();
            return View(products);
        }

        public IActionResult Delete(int id)
        {
            var product = _productService.TGetById(id);
            if (product != null)
            {
                product.IsActive = false;
                _productService.TUpdate(product);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var product = _productService.TGetById(id);
            if (product != null)
            {
                _productService.TDelete(product);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var categories = _categoryService.TGetListAll();
            if (categories != null)
                ViewBag.Categories = categories
                    .Select(c => new SelectListItem { Value = c.CategoryID.ToString(), Text = c.CategoryName })
                    .ToList();
            else
                ViewBag.Categories = new List<SelectListItem>();

            var brands = _brandService.TGetListAll();
            if (brands != null)
                ViewBag.Brands = brands
                    .Select(b => new SelectListItem { Value = b.BrandID.ToString(), Text = b.Name })
                    .ToList();
            else
                ViewBag.Brands = new List<SelectListItem>();

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDto dto)
        {
            

            Product product = new Product()
            {
                SKU = dto.SKU,
                ModelNo = dto.ModelNo,
                Name = dto.Name,
                CategoryID = dto.CategoryID,
                BasePrice = dto.BasePrice,
                CostPrice = dto.CostPrice,
                DiscountedPrice = dto.DiscountedPrice,
                Stock = dto.Stock,
                Description = dto.Description,
                Link1 = dto.Link1,
                Link2 = dto.Link2,
                Link3 = dto.Link3,
                IsFeatured = dto.IsFeatured,
                BrandID = dto.BrandID,
                CreatedAt = DateTime.Now,
                UptatedAt = DateTime.Now,
                IsActive = true,
                Slug = dto.Name.Replace(" ", "-").ToLower()
            };
            _productService.TAdd(product);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _productService.TGetById(id);
            if (value == null)
            {
                return RedirectToAction("Index"); // Ürün bulunamazsa yönlendir.
            }

            var categories = _categoryService.TGetListAll();
            if (categories != null)
                ViewBag.Categories = categories
                    .Select(c => new SelectListItem { Value = c.CategoryID.ToString(), Text = c.CategoryName })
                    .ToList();
            else
                ViewBag.Categories = new List<SelectListItem>();

            var brands = _brandService.TGetListAll();
            if (brands != null)
                ViewBag.Brands = brands
                    .Select(b => new SelectListItem { Value = b.BrandID.ToString(), Text = b.Name })
                    .ToList();
            else
                ViewBag.Brands = new List<SelectListItem>();

            var dto = new UpdateProductDto
            {
                SKU = value.SKU,
                ModelNo = value.ModelNo,
                Name = value.Name,
                CategoryID = value.CategoryID,
                BasePrice = value.BasePrice,
                CostPrice = value.CostPrice,
                DiscountedPrice = value.DiscountedPrice,
                Stock = value.Stock,
                Description = value.Description,
                Link1 = value.Link1,
                Link2 = value.Link2,
                Link3 = value.Link3,
                IsFeatured = value.IsFeatured,
                IsActive = value.IsActive,
                BrandID = value.BrandID,
                ProductID = value.ProductID,
            };

            return View(dto);
        }




        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto p)
        {
            
            var updateProduct = new Product
            {
                ProductID = p.ProductID,
                SKU = p.SKU,
                ModelNo = p.ModelNo,
                Name = p.Name,
                CategoryID = p.CategoryID,
                BasePrice = p.BasePrice,
                CostPrice = p.CostPrice,
                DiscountedPrice = p.DiscountedPrice,
                Stock = p.Stock,
                Description = p.Description,
                Link1 = p.Link1,
                Link2 = p.Link2,
                Link3 = p.Link3,
                IsFeatured = p.IsFeatured,
                IsActive = p.IsActive,
                BrandID = p.BrandID,
                UptatedAt = DateTime.Now,
                Slug = p.Name.Replace(" ", "-").ToLower()
            };


            _productService.TUpdate(updateProduct);

            return RedirectToAction("Index");
        }
    }
}
