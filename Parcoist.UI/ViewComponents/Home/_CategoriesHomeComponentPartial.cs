using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.UI.ViewComponents.Home
{
    public class _CategoriesHomeComponentPartial: ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoriesHomeComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.TGetListAll();
            return View(categories);
        }
    }
}
