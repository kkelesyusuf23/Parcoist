using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.Entity.Concrete;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureeValueController : ControllerBase
    {
        private readonly IFeatureValueService _featureValueService;

        public FeatureeValueController(IFeatureValueService featureValueService)
        {
            _featureValueService = featureValueService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var featureValues = _featureValueService.TGetListAll();
            if (featureValues == null || !featureValues.Any())
            {
                return NotFound("No feature values found.");
            }
            return Ok(featureValues);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var featureValue = _featureValueService.TGetById(id);
            if (featureValue == null)
            {
                return NotFound($"Feature value with ID {id} not found.");
            }
            return Ok(featureValue);


        }
        [HttpPost]
        public IActionResult Create([FromBody] FeatureValue featureValue)
        {
            if (featureValue == null)
            {
                return BadRequest("Feature value data is null.");
            }
            _featureValueService.TAdd(featureValue);
            return CreatedAtAction(nameof(Get), new { id = featureValue.FeatureValueID }, featureValue);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] FeatureValue featureValue)
        {
            if (featureValue == null || featureValue.FeatureValueID != id)
            {
                return BadRequest("Feature value data is invalid.");
            }
            var existingFeatureValue = _featureValueService.TGetById(id);
            if (existingFeatureValue == null)
            {
                return NotFound($"Feature value with ID {id} not found.");
            }
            _featureValueService.TUpdate(featureValue);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var featureValue = _featureValueService.TGetById(id);
            if (featureValue == null)
            {
                return NotFound($"Feature value with ID {id} not found.");
            }
            _featureValueService.TDelete(featureValue);
            return NoContent();
        }
    }
}
