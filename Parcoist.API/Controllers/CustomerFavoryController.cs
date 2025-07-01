using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFavoryController : ControllerBase
    {
        private readonly ICustomerFavoryService _customerFavoryService;

        public CustomerFavoryController(ICustomerFavoryService customerFavoryService)
        {
            _customerFavoryService = customerFavoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customerFavories = _customerFavoryService.TGetListAll();
            if (customerFavories == null || !customerFavories.Any())
            {
                return NotFound("No customer favorites found.");
            }
            return Ok(customerFavories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customerFavory = _customerFavoryService.TGetById(id);
            if (customerFavory == null)
            {
                return NotFound($"Customer favorite with ID {id} not found.");
            }
            return Ok(customerFavory);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UI.Entities.CustomerFavory customerFavory)
        {
            if (customerFavory == null)
            {
                return BadRequest("Customer favorite data is null.");
            }
            _customerFavoryService.TAdd(customerFavory);
            return CreatedAtAction(nameof(Get), new { id = customerFavory.CustomerFavoryID }, customerFavory);
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, [FromBody] UI.Entities.CustomerFavory customerFavory)
        {
            if (customerFavory == null || customerFavory.CustomerFavoryID != id)
            {
                return BadRequest("Customer favorite data is invalid.");
            }
            var existingCustomerFavory = _customerFavoryService.TGetById(id);
            if (existingCustomerFavory == null)
            {
                return NotFound($"Customer favorite with ID {id} not found.");
            }
            _customerFavoryService.TUpdate(customerFavory);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customerFavory = _customerFavoryService.TGetById(id);
            if (customerFavory == null)
            {
                return NotFound($"Customer favorite with ID {id} not found.");
            }
            _customerFavoryService.TDelete(customerFavory);
            return NoContent();
        }
    }
}
