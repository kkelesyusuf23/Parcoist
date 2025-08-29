using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;
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
        public IActionResult Index(int? categoryId, string? brand, decimal? minPrice, decimal? maxPrice)
        {
            var allProducts = _productService.TGetProductsWithAllRelations();

            var query = allProducts.AsQueryable();

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryID == categoryId.Value);

            if (!string.IsNullOrEmpty(brand))
                query = query.Where(p => p.Brand != null && p.Brand.Name.ToLower() == brand.ToLower());

            if (minPrice.HasValue)
                query = query.Where(p => p.DiscountedPrice >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.DiscountedPrice <= maxPrice.Value);

            var filteredProducts = query
    .Select(p => new Product
    {
        // var olan Product alanları
        ProductID = p.ProductID,
        Name = p.Name,
        Brand = p.Brand,
        DiscountedPrice = p.DiscountedPrice,
        ProductImages = p.ProductImages,
        // Yeni eklenen property
        FirstImageUrl = p.ProductImages != null && p.ProductImages.Any()
            ? p.ProductImages.FirstOrDefault().ImagePath
            : "/source/default.png"
    })
    .ToList();


            var allCategories = _categoryService.TGetListAll();

           
            var viewModel = new ProductFilterViewModel
            {
                Products = filteredProducts, // artık direkt FirstImageUrl var
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
