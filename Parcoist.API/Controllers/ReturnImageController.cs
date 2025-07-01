using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnImageController : ControllerBase
    {
        private readonly IReturnImageService _returnImageService;

        public ReturnImageController(IReturnImageService returnImageService)
        {
            _returnImageService = returnImageService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var returnImages = _returnImageService.TGetListAll();
            if (returnImages == null || !returnImages.Any())
            {
                return NotFound("No return images found.");
            }
            return Ok(returnImages);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var returnImage = _returnImageService.TGetById(id);
            if (returnImage == null)
            {
                return NotFound($"Return image with ID {id} not found.");
            }
            return Ok(returnImage);

        }
        [HttpPost]
        public IActionResult Create([FromBody] ReturnImage returnImage)
        {
            if (returnImage == null)
            {
                return BadRequest("Return image data is null.");
            }
            _returnImageService.TAdd(returnImage);
            return CreatedAtAction(nameof(Get), new { id = returnImage.ReturnImageID }, returnImage);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ReturnImage returnImage)
        {
            if (returnImage == null || returnImage.ReturnImageID != id)
            {
                return BadRequest("Return image data is invalid.");
            }
            var existingReturnImage = _returnImageService.TGetById(id);
            if (existingReturnImage == null)
            {
                return NotFound($"Return image with ID {id} not found.");
            }
            _returnImageService.TUpdate(returnImage);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingReturnImage = _returnImageService.TGetById(id);
            if (existingReturnImage == null)
            {
                return NotFound($"Return image with ID {id} not found.");
            }
            _returnImageService.TDelete(existingReturnImage);
            return NoContent(); // 204 No Content
        }
    }
}