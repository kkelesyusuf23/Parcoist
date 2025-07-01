using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnProcessController : ControllerBase
    {
        private readonly IReturnProcessService _returnProcessService;
        public ReturnProcessController(IReturnProcessService returnProcessService)
        {
            _returnProcessService = returnProcessService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var returnProcesses = _returnProcessService.TGetListAll();
            if (returnProcesses == null || !returnProcesses.Any())
            {
                return NotFound("No return processes found.");
            }
            return Ok(returnProcesses);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var returnProcess = _returnProcessService.TGetById(id);
            if (returnProcess == null)
            {
                return NotFound($"Return process with ID {id} not found.");
            }
            return Ok(returnProcess);
        }
        [HttpPost]
        public IActionResult Create([FromBody] ReturnProcess returnProcess)
        {
            if (returnProcess == null)
            {
                return BadRequest("Return process data is null.");
            }
            _returnProcessService.TAdd(returnProcess);
            return CreatedAtAction(nameof(Get), new { id = returnProcess.ReturnProcessID }, returnProcess);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ReturnProcess returnProcess)
        {
            if (returnProcess == null || returnProcess.ReturnProcessID != id)
            {
                return BadRequest("Return process data is invalid.");
            }
            var existingReturnProcess = _returnProcessService.TGetById(id);
            if (existingReturnProcess == null)
            {
                return NotFound($"Return process with ID {id} not found.");
            }
            _returnProcessService.TUpdate(returnProcess);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var returnProcess = _returnProcessService.TGetById(id);
            if (returnProcess == null)
            {
                return NotFound($"Return item with ID {id} not found.");
            }
            _returnProcessService.TDelete(returnProcess);
            return NoContent();
        }

    }
}
