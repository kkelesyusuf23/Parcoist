using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCouponController : ControllerBase
    {
        private readonly ICustomerCouponService _customerCouponService;

        public CustomerCouponController(ICustomerCouponService customerCouponService)
        {
            _customerCouponService = customerCouponService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customerCoupons = _customerCouponService.TGetListAll();
            if (customerCoupons == null || !customerCoupons.Any())
            {
                return NotFound("No customer coupons found.");
            }
            return Ok(customerCoupons);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customerCoupon = _customerCouponService.TGetById(id);
            if (customerCoupon == null)
            {
                return NotFound($"Customer coupon with ID {id} not found.");
            }
            return Ok(customerCoupon);
        }
        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.CustomerCoupon customerCoupon)
        {
            if (customerCoupon == null)
            {
                return BadRequest("Customer coupon data is null.");
            }
            _customerCouponService.TAdd(customerCoupon);
            return CreatedAtAction(nameof(Get), new { id = customerCoupon.CustomerCouponID }, customerCoupon);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UI.Entities.CustomerCoupon customerCoupon)
        {
            if (customerCoupon == null || customerCoupon.CustomerCouponID != id)
            {
                return BadRequest("Customer coupon data is invalid.");
            }
            var existingCustomerCoupon = _customerCouponService.TGetById(id);
            if (existingCustomerCoupon == null)
            {
                return NotFound($"Customer coupon with ID {id} not found.");
            }
            _customerCouponService.TUpdate(customerCoupon);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customerCoupon = _customerCouponService.TGetById(id);
            if (customerCoupon == null)
            {
                return NotFound($"Customer coupon with ID {id} not found.");
            }
            _customerCouponService.TDelete(customerCoupon);
            return NoContent();
        }

    }
}
