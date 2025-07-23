using Microsoft.AspNetCore.Mvc;

namespace Parcoist.UI.ViewComponents.Home
{
    public class _ContactHomeComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
