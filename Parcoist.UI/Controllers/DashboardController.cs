using Microsoft.AspNetCore.Mvc;

namespace Parcoist.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
