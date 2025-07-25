using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

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
