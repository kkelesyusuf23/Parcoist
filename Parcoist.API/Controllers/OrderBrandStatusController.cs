using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBrandStatusController : ControllerBase
    {
        private readonly IOrderBrandStatusService _orderBrandStatusService;

        public OrderBrandStatusController(IOrderBrandStatusService orderBrandStatusService)
        {
            _orderBrandStatusService = orderBrandStatusService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var orderBrandStatuses = _orderBrandStatusService.TGetListAll();
            if (orderBrandStatuses == null || !orderBrandStatuses.Any())
            {
                return NotFound("No order brand statuses found.");
            }
            return Ok(orderBrandStatuses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var orderBrandStatus = _orderBrandStatusService.TGetById(id);
            if (orderBrandStatus == null)
            {
                return NotFound($"Order brand status with ID {id} not found.");
            }
            return Ok(orderBrandStatus);
        }
        [HttpPost]
        public IActionResult Create([FromBody] OrderBrandStatus orderBrandStatus)
        {
            if (orderBrandStatus == null)
            {
                return BadRequest("Order brand status data is null.");
            }
            _orderBrandStatusService.TAdd(orderBrandStatus);
            return CreatedAtAction(nameof(Get), new { id = orderBrandStatus.OrderBrandStatusID }, orderBrandStatus);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] OrderBrandStatus orderBrandStatus)
        {
            if (orderBrandStatus == null || orderBrandStatus.OrderBrandStatusID != id)
            {
                return BadRequest("Order brand status data is invalid.");
            }
            var existingOrderBrandStatus = _orderBrandStatusService.TGetById(id);
            if (existingOrderBrandStatus == null)
            {
                return NotFound($"Order brand status with ID {id} not found.");
            }
            _orderBrandStatusService.TUpdate(orderBrandStatus);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingOrderBrandStatus = _orderBrandStatusService.TGetById(id);
            if (existingOrderBrandStatus == null)
            {
                return NotFound($"Order brand status with ID {id} not found.");
            }
            _orderBrandStatusService.TDelete(existingOrderBrandStatus);
            return NoContent();
        }
    }
}
