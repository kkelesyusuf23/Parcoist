using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.Entity.Concrete;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoController : ControllerBase
    {
        private readonly ILogoService _logoService;

        public LogoController(ILogoService logoService)
        {
            _logoService = logoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var logos = _logoService.TGetListAll();
            if (logos == null || !logos.Any())
            {
                return NotFound("No logos found.");
            }
            return Ok(logos);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var logo = _logoService.TGetById(id);
            if (logo == null)
            {
                return NotFound($"Logo with ID {id} not found.");
            }
            return Ok(logo);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Logo logo)
        {
            if (logo == null)
            {
                return BadRequest("Logo data is null.");
            }
            _logoService.TAdd(logo);
            return CreatedAtAction(nameof(Get), new { id = logo.LogoID }, logo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Logo logo)
        {
            if (logo == null || logo.LogoID != id)
            {
                return BadRequest("Logo data is invalid.");
            }
            var existingLogo = _logoService.TGetById(id);
            if (existingLogo == null)
            {
                return NotFound($"Logo with ID {id} not found.");
            }
            _logoService.TUpdate(logo);
            return NoContent(); // 204 No Content
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var logo = _logoService.TGetById(id);
            if (logo == null)
            {
                return NotFound($"Logo with ID {id} not found.");
            }
            _logoService.TDelete(logo);
            return NoContent(); // 204 No Content

        }
    }

}