using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnStatusController : ControllerBase
    {
        private readonly IReturnStatusService _returnStatusService;

        public ReturnStatusController(IReturnStatusService returnStatusService)
        {
            _returnStatusService = returnStatusService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var returnStatus = _returnStatusService.TGetListAll();
            if (returnStatus == null || !returnStatus.Any())
            {
                return NotFound("No Return Request found");
            }
            return Ok(returnStatus);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var returnStatus = _returnStatusService.TGetById(id);
            if (returnStatus == null)
            {
                return NotFound($"Return Status with ID {id} not found.");
            }
            return Ok(returnStatus);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ReturnStatus returnStatus)
        {
            if (returnStatus == null)
            {
                return BadRequest("Return Status data is null.");
            }
            _returnStatusService.TAdd(returnStatus);
            return CreatedAtAction(nameof(Get), new { id = returnStatus.ReturnStatusID }, returnStatus);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ReturnStatus returnStatus)
        {
            if (returnStatus == null || returnStatus.ReturnStatusID != id)
            {
                return BadRequest("Return Status data is invalid.");
            }
            var existingStatusRequest = _returnStatusService.TGetById(id);
            if (existingStatusRequest == null)
            {
                return NotFound($"Return Request with ID {id} not found.");
            }
            _returnStatusService.TUpdate(returnStatus);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var returnRequest = _returnStatusService.TGetById(id);
            if (returnRequest == null)
            {
                return NotFound($"Return Request with ID {id} not found.");
            }
            _returnStatusService.TDelete(returnRequest);
            return NoContent();
        }
    }
}
