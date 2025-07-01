using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orderItems = _orderItemService.TGetListAll();
            if (orderItems == null || !orderItems.Any())
            {
                return NotFound("No order items found.");
            }
            return Ok(orderItems);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var orderItem = _orderItemService.TGetById(id);
            if (orderItem == null)
            {
                return NotFound($"Order item with ID {id} not found.");
            }
            return Ok(orderItem);
        }
        [HttpPost]
        public IActionResult Create([FromBody] OrderItem orderItem)
        {
            if (orderItem == null)
            {
                return BadRequest("Order item data is null.");
            }
            _orderItemService.TAdd(orderItem);
            return CreatedAtAction(nameof(Get), new { id = orderItem.OrderItemID }, orderItem);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderItem orderItem)
        {
            if (orderItem == null || orderItem.OrderItemID != id)
            {
                return BadRequest("Order item data is invalid.");
            }
            var existingOrderItem = _orderItemService.TGetById(id);
            if (existingOrderItem == null)
            {
                return NotFound($"Order item with ID {id} not found.");
            }
            _orderItemService.TUpdate(orderItem);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var orderItem = _orderItemService.TGetById(id);
            if (orderItem == null)
            {
                return NotFound($"Order item with ID {id} not found.");
            }
            _orderItemService.TDelete(orderItem);
            return NoContent();
        }
    }
}