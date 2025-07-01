using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.TGetListAll();
            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found.");
            }
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _orderService.TGetById(id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            return Ok(order);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order data is null.");
            }
            _orderService.TAdd(order);
            return CreatedAtAction(nameof(Get), new { id = order.OrderID }, order);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order order)
        {
            if (order == null || order.OrderID != id)
            {
                return BadRequest("Order data is invalid.");
            }
            var existingOrder = _orderService.TGetById(id);
            if (existingOrder == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            _orderService.TUpdate(order);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingOrder = _orderService.TGetById(id);
            if (existingOrder == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            _orderService.TDelete(existingOrder);
            return NoContent();
        }
    }
}
