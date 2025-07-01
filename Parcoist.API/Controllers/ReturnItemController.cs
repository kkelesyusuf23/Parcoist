using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnItemController : ControllerBase
    {
        private readonly IReturnItemService _returnItemService;

        public ReturnItemController(IReturnItemService returnItemService)
        {
            _returnItemService = returnItemService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var returnItems = _returnItemService.TGetListAll();
            if (returnItems == null || !returnItems.Any())
            {
                return NotFound("No return items found.");
            }
            return Ok(returnItems);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var returnItem = _returnItemService.TGetById(id);
            if (returnItem == null)
            {
                return NotFound($"Return item with ID {id} not found.");
            }
            return Ok(returnItem);

        }
        [HttpPost]
        public ActionResult Create([FromBody] ReturnItem returnItem)
        {
            if (returnItem == null)
            {
                return BadRequest("Return item data is null.");
            }
            _returnItemService.TAdd(returnItem);
            return CreatedAtAction(nameof(Get), new { id = returnItem.ReturnItemID }, returnItem);
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] ReturnItem returnItem)
        {
            if (returnItem == null || returnItem.ReturnItemID != id)
            {
                return BadRequest("Return item data is invalid.");
            }
            var existingReturnItem = _returnItemService.TGetById(id);
            if (existingReturnItem == null)
            {
                return NotFound($"Return item with ID {id} not found.");
            }
            _returnItemService.TUpdate(returnItem);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var returnItem = _returnItemService.TGetById(id);
            if (returnItem == null)
            {
                return NotFound($"Return item with ID {id} not found.");
            }
            _returnItemService.TDelete(returnItem);
            return NoContent();
        }
    }
}