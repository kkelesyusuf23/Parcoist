using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryService.TGetListAll();
            if (categories == null || !categories.Any())
            {
                return NotFound("No categories found.");
            }
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _categoryService.TGetById(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.Category category)
        {
            if (category == null)
            {
                return BadRequest("Category data is null.");
            }
            _categoryService.TAdd(category);
            return CreatedAtAction(nameof(Get), new { id = category.CategoryID }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UI.Entities.Category category)
        {
            if (category == null || category.CategoryID != id)
            {
                return BadRequest("Category data is invalid.");
            }
            var existingCategory = _categoryService.TGetById(id);
            if (existingCategory == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            _categoryService.TUpdate(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCategory = _categoryService.TGetById(id);
            if (existingCategory == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            _categoryService.TDelete(existingCategory);
            return NoContent();


        }
    }
}
