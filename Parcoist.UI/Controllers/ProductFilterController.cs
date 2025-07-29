using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.UI.Controllers
{
    public class ProductFilterController : Controller
    {
        private readonly IProductService _productService;

        public ProductFilterController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.TGetProductsWithAllRelations();
            return View(products);
        }
    }
}
