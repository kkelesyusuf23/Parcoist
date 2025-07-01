using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.TGetListAll();
            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.TGetById(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(product);

        }
        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.Product product)
        {
            if (product == null)
            {
                return BadRequest("Product data is null.");
            }
            _productService.TAdd(product);
            return CreatedAtAction(nameof(Get), new { id = product.ProductID }, product);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UI.Entities.Product product)
        {
            if (product == null || product.ProductID != id)
            {
                return BadRequest("Product data is invalid.");
            }
            var existingProduct = _productService.TGetById(id);
            if (existingProduct == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            _productService.TUpdate(product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.TGetById(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            _productService.TDelete(product);
            return NoContent();
        }

    }
}