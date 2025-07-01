using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerService.TGetListAll();
            if (customers == null || !customers.Any())
            {
                return NotFound("No customers found.");
            }
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _customerService.TGetById(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            return Ok(customer);

        }
        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is null.");
            }
            _customerService.TAdd(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.CustomerID }, customer);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UI.Entities.Customer customer)
        {
            if (customer == null || customer.CustomerID != id)
            {
                return BadRequest("Customer data is invalid.");
            }
            var existingCustomer = _customerService.TGetById(id);
            if (existingCustomer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            _customerService.TUpdate(customer);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCustomer = _customerService.TGetById(id);
            if (existingCustomer == null)
            {
                return NotFound($"Customer with ID {id} not found.");
            }
            _customerService.TDelete(existingCustomer);
            return NoContent();
        }
    }
}