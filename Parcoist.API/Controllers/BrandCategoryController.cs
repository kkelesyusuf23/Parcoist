using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandCategoryController : ControllerBase
    {
        private readonly IBrandCategoryService _brandCategoryService;

        public BrandCategoryController(IBrandCategoryService brandCategoryService)
        {
            _brandCategoryService = brandCategoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brandCategories = _brandCategoryService.TGetListAll();
            if (brandCategories == null || !brandCategories.Any())
            {
                return NotFound("No brand categories found.");
            }
            return Ok(brandCategories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var brandCategory = _brandCategoryService.TGetById(id);
            if (brandCategory == null)
            {
                return NotFound($"Brand category with ID {id} not found.");
            }
            return Ok(brandCategory);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BrandCategory brandCategory)
        {
            if (brandCategory == null)
            {
                return BadRequest("Brand category data is null.");
            }
            _brandCategoryService.TAdd(brandCategory);
            return CreatedAtAction(nameof(Get), new { id = brandCategory.BrandCategoryID }, brandCategory);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] BrandCategory brandCategory)
        {
            if (brandCategory == null || brandCategory.BrandCategoryID != id)
            {
                return BadRequest("Brand category data is invalid.");
            }
            var existingBrandCategory = _brandCategoryService.TGetById(id);
            if (existingBrandCategory == null)
            {
                return NotFound($"Brand category with ID {id} not found.");
            }
            _brandCategoryService.TUpdate(brandCategory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var brandCategory = _brandCategoryService.TGetById(id);
            if (brandCategory == null)
            {
                return NotFound($"Brand category with ID {id} not found.");
            }
            _brandCategoryService.TDelete(brandCategory);
            return NoContent();

        }
    }
}