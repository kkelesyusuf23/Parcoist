using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryStatusController : ControllerBase
    {
        private readonly IDeliveryStatusService _deliveryStatusService;

        public DeliveryStatusController(IDeliveryStatusService deliveryStatusService)
        {
            _deliveryStatusService = deliveryStatusService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var deliveryStatuses = _deliveryStatusService.TGetListAll();
            if (deliveryStatuses == null || !deliveryStatuses.Any())
            {
                return NotFound("No delivery statuses found.");
            }
            return Ok(deliveryStatuses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var deliveryStatus = _deliveryStatusService.TGetById(id);
            if (deliveryStatus == null)
            {
                return NotFound($"Delivery status with ID {id} not found.");
            }
            return Ok(deliveryStatus);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.DeliveryStatus deliveryStatus)
        {
            if (deliveryStatus == null)
            {
                return BadRequest("Delivery status data is null.");
            }
            _deliveryStatusService.TAdd(deliveryStatus);
            return CreatedAtAction(nameof(Get), new { id = deliveryStatus.DeliveryStatusID }, deliveryStatus);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UI.Entities.DeliveryStatus deliveryStatus)
        {
            if (deliveryStatus == null || deliveryStatus.DeliveryStatusID != id)
            {
                return BadRequest("Delivery status data is invalid.");
            }
            var existingDeliveryStatus = _deliveryStatusService.TGetById(id);
            if (existingDeliveryStatus == null)
            {
                return NotFound($"Delivery status with ID {id} not found.");
            }
            _deliveryStatusService.TUpdate(deliveryStatus);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingDeliveryStatus = _deliveryStatusService.TGetById(id);
            if (existingDeliveryStatus == null)
            {
                return NotFound($"Delivery status with ID {id} not found.");
            }
            _deliveryStatusService.TDelete(existingDeliveryStatus);
            return NoContent();
        }
    }
}
