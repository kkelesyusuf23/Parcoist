using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Models; // ViewModel için
using System.Linq;

namespace Parcoist.UI.Controllers
{
    public class HomeCategoryController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public HomeCategoryController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            
            var categories = _categoryService.TGetListAll();

            var viewModel = categories.Select(category => new CategoryWithProductsViewModel
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                Products = _productService.TGetProductsWithAllRelations()
                            .Where(p => p.CategoryID == category.CategoryID && p.IsActive)
                            .ToList()
            }).ToList();

            return View(viewModel);
        }
    }
}
