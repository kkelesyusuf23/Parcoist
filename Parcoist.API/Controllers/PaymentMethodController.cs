using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var paymentMethods = _paymentMethodService.TGetListAll();
            if (paymentMethods == null || !paymentMethods.Any())
            {
                return NotFound("No payment methods found.");
            }
            return Ok(paymentMethods);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var paymentMethod = _paymentMethodService.TGetById(id);
            if (paymentMethod == null)
            {
                return NotFound($"Payment method with ID {id} not found.");
            }
            return Ok(paymentMethod);
        }
        [HttpPost]
        public IActionResult Create([FromBody] PaymentMethod paymentMethod)
        {
            if (paymentMethod == null)
            {
                return BadRequest("Payment method data is null.");
            }
            _paymentMethodService.TAdd(paymentMethod);
            return CreatedAtAction(nameof(Get), new { id = paymentMethod.PaymentMethodID }, paymentMethod);
        }
        [HttpPost]
        public IActionResult Update(int id, [FromBody] PaymentMethod paymentMethod)
        {
            if (paymentMethod == null || paymentMethod.PaymentMethodID != id)
            {
                return BadRequest("Payment method data is invalid.");
            }
            var existingPaymentMethod = _paymentMethodService.TGetById(id);
            if (existingPaymentMethod == null)
            {
                return NotFound($"Payment method with ID {id} not found.");
            }
            _paymentMethodService.TUpdate(paymentMethod);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var paymentMethod = _paymentMethodService.TGetById(id);
            if (paymentMethod == null)
            {
                return NotFound($"Payment method with ID {id} not found.");
            }
            _paymentMethodService.TDelete(paymentMethod);
            return NoContent();
        }
    }
}
