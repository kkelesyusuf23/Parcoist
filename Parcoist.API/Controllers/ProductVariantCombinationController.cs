using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.Entity.Concrete;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantCombinationController : ControllerBase
    {
        private readonly IProductVariantCombinationService _productVariantCombinationService;

        public ProductVariantCombinationController(IProductVariantCombinationService productVariantCombinationService)
        {
            _productVariantCombinationService = productVariantCombinationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var combinations = _productVariantCombinationService.TGetListAll();
            if (combinations == null || !combinations.Any())
            {
                return NotFound("No product variant combinations found.");
            }
            return Ok(combinations);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var combination = _productVariantCombinationService.TGetById(id);
            if (combination == null)
            {
                return NotFound($"Product variant combination with ID {id} not found.");
            }
            return Ok(combination);
        }
        [HttpPost]
        public IActionResult Create([FromBody] ProductVariantCombination productVariantCombination)
        {
            if (productVariantCombination == null)
            {
                return BadRequest("Product variant combination data is null.");
            }
            _productVariantCombinationService.TAdd(productVariantCombination);
            return CreatedAtAction(nameof(Get), new { id = productVariantCombination.ProductVariantCombinationID }, productVariantCombination);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductVariantCombination productVariantCombination)
        {
            if (productVariantCombination == null || productVariantCombination.ProductVariantCombinationID != id)
            {
                return BadRequest("Product variant combination data is invalid.");
            }
            var existingCombination = _productVariantCombinationService.TGetById(id);
            if (existingCombination == null)
            {
                return NotFound($"Product variant combination with ID {id} not found.");
            }
            _productVariantCombinationService.TUpdate(productVariantCombination);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCombination = _productVariantCombinationService.TGetById(id);
            if (existingCombination == null)
            {
                return NotFound($"Product variant combination with ID {id} not found.");
            }
            _productVariantCombinationService.TDelete(existingCombination);
            return NoContent();
        }

    }
}
