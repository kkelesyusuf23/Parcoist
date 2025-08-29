using Microsoft.AspNetCore.Mvc;

namespace YourApp.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            // Diğer hata kodları için (500, 403 vs.)
            return View("Error");
        }
    }
}
