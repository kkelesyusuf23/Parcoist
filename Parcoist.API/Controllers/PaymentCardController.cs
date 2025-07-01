using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentCardController : ControllerBase
    {
        private readonly IPaymentCardService _paymentCardService;

        public PaymentCardController(IPaymentCardService paymentCardService)
        {
            _paymentCardService = paymentCardService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var paymentCards = _paymentCardService.TGetListAll();
            if (paymentCards == null || !paymentCards.Any())
            {
                return NotFound("No payment cards found.");
            }
            return Ok(paymentCards);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var paymentCard = _paymentCardService.TGetById(id);
            if (paymentCard == null)
            {
                return NotFound($"Payment card with ID {id} not found.");
            }
            return Ok(paymentCard);
        }
        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.PaymentCard paymentCard)
        {
            if (paymentCard == null)
            {
                return BadRequest("Payment card data is null.");
            }
            _paymentCardService.TAdd(paymentCard);
            return CreatedAtAction(nameof(Get), new { id = paymentCard.PaymentCardID }, paymentCard);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PaymentCard paymentCard)
        {
            if (paymentCard == null || paymentCard.PaymentCardID != id)
            {
                return BadRequest("Payment card data is invalid.");
            }
            var existingPaymentCard = _paymentCardService.TGetById(id);
            if (existingPaymentCard == null)
            {
                return NotFound($"Payment card with ID {id} not found.");
            }
            _paymentCardService.TUpdate(paymentCard);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var paymentCard = _paymentCardService.TGetById(id);
            if (paymentCard == null)
            {
                return NotFound($"Payment card with ID {id} not found.");
            }
            _paymentCardService.TDelete(paymentCard);
            return NoContent();
        }
    }
}