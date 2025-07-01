using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantValueController : ControllerBase
    {
        private readonly IProductVariantValueService _productVariantValueService;

        public ProductVariantValueController(IProductVariantValueService productVariantValueService)
        {
            _productVariantValueService = productVariantValueService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var productVariantValues = _productVariantValueService.TGetListAll();
            if (productVariantValues == null || !productVariantValues.Any())
            {
                return NotFound("No product variant values found.");
            }
            return Ok(productVariantValues);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var productVariantValue = _productVariantValueService.TGetById(id);
            if (productVariantValue == null)
            {
                return NotFound($"Product variant value with ID {id} not found.");
            }
            return Ok(productVariantValue);
        }
        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.ProductVariantValue productVariantValue)
        {
            if (productVariantValue == null)
            {
                return BadRequest("Product variant value data is null.");
            }
            _productVariantValueService.TAdd(productVariantValue);
            return CreatedAtAction(nameof(Get), new { id = productVariantValue.ProductVariantValueID }, productVariantValue);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UI.Entities.ProductVariantValue productVariantValue)
        {
            if (productVariantValue == null || productVariantValue.ProductVariantValueID != id)
            {
                return BadRequest("Product variant value data is invalid.");
            }
            var existingProductVariantValue = _productVariantValueService.TGetById(id);
            if (existingProductVariantValue == null)
            {
                return NotFound($"Product variant value with ID {id} not found.");
            }
            _productVariantValueService.TUpdate(productVariantValue);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProductVariantValue = _productVariantValueService.TGetById(id);
            if (existingProductVariantValue == null)
            {
                return NotFound($"Product variant value with ID {id} not found.");
            }
            _productVariantValueService.TDelete(existingProductVariantValue);
            return NoContent();
        }
    }
}