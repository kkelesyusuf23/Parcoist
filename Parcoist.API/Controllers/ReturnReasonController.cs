using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnReasonController : ControllerBase
    {
        private readonly IReturnReasonService _returnReasonService;

        public ReturnReasonController(IReturnReasonService returnReasonService)
        {
            _returnReasonService = returnReasonService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var returnReasons = _returnReasonService.TGetListAll();
            if(returnReasons == null || !returnReasons.Any())
            {
                return NotFound("No Return Reasons found");
            }
            return Ok(returnReasons);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var returnReasons = _returnReasonService.TGetById(id);
            if(returnReasons == null)
            {
                return NotFound($"Return reason with ID {id} not found.");
            }
            return Ok(returnReasons);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ReturnReason returnReason)
        {
            if(returnReason == null)
            {
                return BadRequest("Return Reason data is null.");
            }
            _returnReasonService.TAdd(returnReason);
            return CreatedAtAction(nameof(Get), new { id = returnReason.ReturnReasonID }, returnReason);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ReturnReason returnReason)
        {
            if (returnReason == null || returnReason.ReturnReasonID != id)
            {
                return BadRequest("Return reason data is invalid.");
            }
            var existingReturnProcess = _returnReasonService.TGetById(id);
            if (existingReturnProcess == null)
            {
                return NotFound($"Return reason with ID {id} not found.");
            }
            _returnReasonService.TUpdate(returnReason);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var returnReason = _returnReasonService.TGetById(id);
            if (returnReason == null)
            {
                return NotFound($"Return reason with ID {id} not found.");
            }
            _returnReasonService.TDelete(returnReason);
            return NoContent();
        }
    }
}
