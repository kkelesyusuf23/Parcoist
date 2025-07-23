using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.UI.ViewComponents.Home
{
    public class _SliderHomeComponentPartial:ViewComponent
    {
        private readonly ISliderService _sliderService;

        public _SliderHomeComponentPartial(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IViewComponentResult Invoke()
        {
            var sliders = _sliderService.TGetListAll();
            return View(sliders);
        }
    }
}
