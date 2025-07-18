using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.UI.Controllers
{
    public class BrandCategoryController : Controller
    {
        private readonly IBrandCategoryService _brandCategoryService;

        public BrandCategoryController(IBrandCategoryService brandCategoryService)
        {
            _brandCategoryService = brandCategoryService;
        }

        public IActionResult Index()
        {
            var brandCategories = _brandCategoryService.TGetListAll();
            return View(brandCategories);
        }

    }
}
