using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.Entity.Concrete;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var slider = _sliderService.TGetListAll();
            if (slider == null || !slider.Any())
            {
                return NotFound("No slider found");
            }
            return Ok(slider);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var slider = _sliderService.TGetById(id);
            if (slider == null)
            {
                return NotFound($"Slider with ID {id} not found.");
            }
            return Ok(slider);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Slider slider)
        {
            if (slider == null)
            {
                return BadRequest("Slider data is null.");
            }
            _sliderService.TAdd(slider);
            return CreatedAtAction(nameof(Get), new { id = slider.SliderID }, slider);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Slider slider)
        {
            if (slider == null || slider.SliderID != id)
            {
                return BadRequest("Slider data is invalid.");
            }
            var existingSliderRequest = _sliderService.TGetById(id);
            if (existingSliderRequest == null)
            {
                return NotFound($"Slider with ID {id} not found.");
            }
            _sliderService.TUpdate(slider);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var slider = _sliderService.TGetById(id);
            if (slider == null)
            {
                return NotFound($"Slider with ID {id} not found.");
            }
            _sliderService.TDelete(slider);
            return NoContent();
        }

    }
}
