using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.UI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            var brands = _brandService.TGetListAll();
            return View(brands);
        }

        public IActionResult Details(int id)
        {
            var brand = _brandService.TGetById(id);
            return View(brand);
        }

    }
}
