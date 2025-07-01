using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var productImages = _productImageService.TGetListAll();
            if (productImages == null || !productImages.Any())
            {
                return NotFound("No product images found.");
            }
            return Ok(productImages);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var productImage = _productImageService.TGetById(id);
            if (productImage == null)
            {
                return NotFound($"Product image with ID {id} not found.");
            }
            return Ok(productImage);
        }
        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.ProductImage productImage)
        {
            if (productImage == null)
            {
                return BadRequest("Product image data is null.");
            }
            _productImageService.TAdd(productImage);
            return CreatedAtAction(nameof(Get), new { id = productImage.ProductImageID }, productImage);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UI.Entities.ProductImage productImage)
        {
            if (productImage == null || productImage.ProductImageID != id)
            {
                return BadRequest("Product image data is invalid.");
            }
            var existingProductImage = _productImageService.TGetById(id);
            if (existingProductImage == null)
            {
                return NotFound($"Product image with ID {id} not found.");
            }
            _productImageService.TUpdate(productImage);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productImage = _productImageService.TGetById(id);
            if (productImage == null)
            {
                return NotFound($"Product image with ID {id} not found.");
            }
            _productImageService.TDelete(productImage);
            return NoContent();
        }
    }
}