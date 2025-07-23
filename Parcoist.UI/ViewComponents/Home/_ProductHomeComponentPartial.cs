using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.UI.ViewComponents.Home
{
    public class _ProductHomeComponentPartial: ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductHomeComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productService.TGetProductsWithAllRelations();
            return View(products);
        }
    }
}
