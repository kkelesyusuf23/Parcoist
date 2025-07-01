using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureTypeCategoryController : ControllerBase
    {
        private readonly IFeatureTypeCategoryService _featureTypeCategoryService;

        public FeatureTypeCategoryController(IFeatureTypeCategoryService featureTypeCategoryService)
        {
            _featureTypeCategoryService = featureTypeCategoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var featureTypeCategories = _featureTypeCategoryService.TGetListAll();
            if (featureTypeCategories == null || !featureTypeCategories.Any())
            {
                return NotFound("No feature type categories found.");
            }
            return Ok(featureTypeCategories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var featureTypeCategory = _featureTypeCategoryService.TGetById(id);
            if (featureTypeCategory == null)
            {
                return NotFound($"Feature type category with ID {id} not found.");
            }
            return Ok(featureTypeCategory);


        }

        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.FeatureTypeCategory featureTypeCategory)
        {
            if (featureTypeCategory == null)
            {
                return BadRequest("Feature type category data is null.");
            }
            _featureTypeCategoryService.TAdd(featureTypeCategory);
            return CreatedAtAction(nameof(Get), new { id = featureTypeCategory.FeatureTypeCategoryID }, featureTypeCategory);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UI.Entities.FeatureTypeCategory featureTypeCategory)
        {
            if (featureTypeCategory == null || featureTypeCategory.FeatureTypeCategoryID != id)
            {
                return BadRequest("Feature type category data is invalid.");
            }
            var existingFeatureTypeCategory = _featureTypeCategoryService.TGetById(id);
            if (existingFeatureTypeCategory == null)
            {
                return NotFound($"Feature type category with ID {id} not found.");
            }
            _featureTypeCategoryService.TUpdate(featureTypeCategory);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var featureTypeCategory = _featureTypeCategoryService.TGetById(id);
            if (featureTypeCategory == null)
            {
                return NotFound($"Feature type category with ID {id} not found.");
            }
            _featureTypeCategoryService.TDelete(featureTypeCategory);
            return NoContent();
        }
    }
}