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
                ).ToList();

            var allCategories = _categoryService.TGetListAll(); // Kategori listesini direkt servisten al

            var viewModel = new ProductFilterViewModel
            {
                Products = filteredProducts,
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
