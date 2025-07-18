using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureTypeController : ControllerBase
    {
        private readonly IFeatureTypeCateg _featureTypeService;

        public FeatureTypeController(IFeatureTypeCateg featureTypeService)
        {
            _featureTypeService = featureTypeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var featureTypes = _featureTypeService.TGetListAll();
            if (featureTypes == null || !featureTypes.Any())
            {
                return NotFound("No feature types found.");
            }
            return Ok(featureTypes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var featureType = _featureTypeService.TGetById(id);
            if (featureType == null)
            {
                return NotFound($"Feature type with ID {id} not found.");
            }
            return Ok(featureType);
        }
        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.FeatureType featureType)
        {
            if (featureType == null)
            {
                return BadRequest("Feature type data is null.");
            }
            _featureTypeService.TAdd(featureType);
            return CreatedAtAction(nameof(Get), new { id = featureType.FeatureTypeID }, featureType);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UI.Entities.FeatureType featureType)
        {
            if (featureType == null || featureType.FeatureTypeID != id)
            {
                return BadRequest("Feature type data is invalid.");
            }
            var existingFeatureType = _featureTypeService.TGetById(id);
            if (existingFeatureType == null)
            {
                return NotFound($"Feature type with ID {id} not found.");
            }
            _featureTypeService.TUpdate(featureType);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var featureType = _featureTypeService.TGetById(id);
            if (featureType == null)
            {
                return NotFound($"Feature type with ID {id} not found.");
            }
            _featureTypeService.TDelete(featureType);
            return NoContent();
        }
    }
}