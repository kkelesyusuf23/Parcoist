using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var deliveries = _deliveryService.TGetListAll();
            if (deliveries == null || !deliveries.Any())
            {
                return NotFound("No deliveries found.");
            }
            return Ok(deliveries);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var delivery = _deliveryService.TGetById(id);
            if (delivery == null)
            {
                return NotFound($"Delivery with ID {id} not found.");
            }
            return Ok(delivery);

        }
        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.Delivery delivery)
        {
            if (delivery == null)
            {
                return BadRequest("Delivery data is null.");
            }
            _deliveryService.TAdd(delivery);
            return CreatedAtAction(nameof(Get), new { id = delivery.DeliveryID }, delivery);
        }
        [HttpPost]
        public IActionResult Update(int id, [FromBody] UI.Entities.Delivery delivery)
        {
            if (delivery == null || delivery.DeliveryID != id)
            {
                return BadRequest("Delivery data is invalid.");
            }
            var existingDelivery = _deliveryService.TGetById(id);
            if (existingDelivery == null)
            {
                return NotFound($"Delivery with ID {id} not found.");
            }
            _deliveryService.TUpdate(delivery);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delivery = _deliveryService.TGetById(id);
            if (delivery == null)
            {
                return NotFound($"Delivery with ID {id} not found.");
            }
            _deliveryService.TDelete(delivery);
            return NoContent();
        }
    }
}
