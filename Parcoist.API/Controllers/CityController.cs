using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var cities = _cityService.TGetListAll();
            if (cities == null || !cities.Any())
            {
                return NotFound("No cities found.");
            }
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var city = _cityService.TGetById(id);
            if (city == null)
            {
                return NotFound($"City with ID {id} not found.");
            }
            return Ok(city);

        }
        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.City city)
        {
            if (city == null)
            {
                return BadRequest("City data is null.");
            }
            _cityService.TAdd(city);
            return CreatedAtAction(nameof(Get), new { id = city.CityID }, city);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UI.Entities.City city)
        {
            if (city == null || city.CityID != id)
            {
                return BadRequest("City data is invalid.");
            }
            var existingCity = _cityService.TGetById(id);
            if (existingCity == null)
            {
                return NotFound($"City with ID {id} not found.");
            }
            _cityService.TUpdate(city);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCity = _cityService.TGetById(id);
            if (existingCity == null)
            {
                return NotFound($"City with ID {id} not found.");
            }
            _cityService.TDelete(existingCity);
            return NoContent();
        }
    }
}