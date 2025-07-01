using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brands = _brandService.TGetListAll();
            if (brands == null || !brands.Any())
            {
                return NotFound("No brands found.");
            }
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var brand = _brandService.TGetById(id);
            if (brand == null)
            {
                return NotFound($"Brand with ID {id} not found.");
            }
            return Ok(brand);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Brand brand)
        {
            if (brand == null)
            {
                return BadRequest("Brand data is null.");
            }
            _brandService.TAdd(brand);
            return CreatedAtAction(nameof(Get), new { id = brand.BrandID }, brand);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Brand brand)
        {
            if (brand == null || brand.BrandID != id)
            {
                return BadRequest("Brand data is invalid.");
            }
            var existingBrand = _brandService.TGetById(id);
            if (existingBrand == null)
            {
                return NotFound($"Brand with ID {id} not found.");
            }
            _brandService.TUpdate(brand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var brand = _brandService.TGetById(id);
            if (brand == null)
            {
                return NotFound($"Brand with ID {id} not found.");
            }
            _brandService.TDelete(brand);
            return NoContent();
        }
    }
}
