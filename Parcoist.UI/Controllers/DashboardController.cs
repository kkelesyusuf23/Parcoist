using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Parcoist.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            // Kullanıcı giriş yapmış mı kontrol et
            var userId = HttpContext.Session.GetInt32("UserID");

            if (userId == null)
            {
                // Giriş yapılmamışsa login sayfasına yönlendir
                return RedirectToAction("Login", "Auth");
            }

            // Giriş yapılmışsa dashboard sayfasını göster
            return View();
        }
    }
}
