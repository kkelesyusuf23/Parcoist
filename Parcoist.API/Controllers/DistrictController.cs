using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDisctrictService _districtService;

        public DistrictController(IDisctrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var districts = _districtService.TGetListAll();
            if (districts == null || !districts.Any())
            {
                return NotFound("No districts found.");
            }
            return Ok(districts);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var district = _districtService.TGetById(id);
            if (district == null)
            {
                return NotFound($"District with ID {id} not found.");
            }
            return Ok(district);
        }
        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.District district)
        {
            if (district == null)
            {
                return BadRequest("District data is null.");
            }
            _districtService.TAdd(district);
            return CreatedAtAction(nameof(Get), new { id = district.DistrictID }, district);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UI.Entities.District district)
        {
            if (district == null || district.DistrictID != id)
            {
                return BadRequest("District data is invalid.");
            }
            var existingDistrict = _districtService.TGetById(id);
            if (existingDistrict == null)
            {
                return NotFound($"District with ID {id} not found.");
            }
            _districtService.TUpdate(district);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var district = _districtService.TGetById(id);
            if (district == null)
            {
                return NotFound($"District with ID {id} not found.");
            }
            _districtService.TDelete(district);
            return NoContent();
        }
    }
}
