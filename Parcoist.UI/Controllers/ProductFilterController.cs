using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Models;

namespace Parcoist.UI.Controllers
{
    public class ProductFilterController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductFilterController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index(int? categoryId, string brand, decimal? minPrice, decimal? maxPrice)
        {
            var allProducts = _productService.TGetProductsWithAllRelations();

            var filteredProducts = allProducts
                .Where(p =>
                    (!categoryId.HasValue || p.CategoryID == categoryId.Value) &&
                    (string.IsNullOrEmpty(brand) || p.Brand?.Name == brand) &&
                    (!minPrice.HasValue || p.DiscountedPrice >= minPrice) &&
                    (!maxPrice.HasValue || p.DiscountedPrice <= maxPrice)
                )
                .Select(p => new
                {
                    Product = p,
                    FirstImage = p.ProductImages != null && p.ProductImages.Any()
                        ? p.ProductImages.FirstOrDefault().ImagePath // ilk resim
                        : "/images/no-image.png" // resim yoksa default resim
                })
                .ToList();

            var allCategories = _categoryService.TGetListAll();

            var viewModel = new ProductFilterViewModel
            {
                Products = filteredProducts.Select(p => {
                    p.Product.FirstImageUrl = p.FirstImage; // Ürün modelinde ek property
                    return p.Product;
                }).ToList(),
                Categories = allCategories,
                Brands = allProducts
                    .Select(p => p.Brand?.Name)
                    .Where(b => !string.IsNullOrEmpty(b))
                    .Distinct()
                    .ToList(),
                Prices = new List<decimal> { 50, 100, 200, 300 },
                SelectedCategoryId = categoryId,
                SelectedBrand = brand,
                MinPrice = minPrice,
                MaxPrice = maxPrice
            };

            return View(viewModel);
        }





    }
}
