using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnRequestController : ControllerBase
    {
        private readonly IReturnRequestService _returnRequestService;

        public ReturnRequestController(IReturnRequestService returnRequestService)
        {
            _returnRequestService = returnRequestService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var returnRequest = _returnRequestService.TGetListAll();
            if (returnRequest == null || !returnRequest.Any())
            {
                return NotFound("No Return Request found");
            }
            return Ok(returnRequest);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var returnRequest = _returnRequestService.TGetById(id);
            if (returnRequest == null)
            {
                return NotFound($"Return Request with ID {id} not found.");
            }
            return Ok(returnRequest);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ReturnRequest returnRequest)
        {
            if (returnRequest == null)
            {
                return BadRequest("Return Request data is null.");
            }
            _returnRequestService.TAdd(returnRequest);
            return CreatedAtAction(nameof(Get), new { id = returnRequest.ReturnRequestID }, returnRequest);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ReturnRequest returnRequest)
        {
            if (returnRequest == null || returnRequest.ReturnRequestID != id)
            {
                return BadRequest("Return Request data is invalid.");
            }
            var existingReturnRequest = _returnRequestService.TGetById(id);
            if (existingReturnRequest == null)
            {
                return NotFound($"Return Request with ID {id} not found.");
            }
            _returnRequestService.TUpdate(returnRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var returnRequest = _returnRequestService.TGetById(id);
            if (returnRequest == null)
            {
                return NotFound($"Return Request with ID {id} not found.");
            }
            _returnRequestService.TDelete(returnRequest);
            return NoContent();
        }
    }
}
