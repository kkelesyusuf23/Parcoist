using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly IAdressService _adressService;

        public AdressController(IAdressService adressService)
        {
            _adressService = adressService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var addresses = _adressService.TGetListAll();
            if (addresses == null || !addresses.Any())
            {
                return NotFound("No admins found.");
            }
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var address = _adressService.TGetById(id);
            if (address == null)
            {
                return NotFound($"Address with ID {id} not found.");
            }
            return Ok(address);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Adress address)
        {
            if (address == null)
            {
                return BadRequest("Address data is null.");
            }
            _adressService.TAdd(address);
            return CreatedAtAction(nameof(Get), new { id = address.AdressID }, address);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Adress address)
        {
            if (address == null || address.AdressID != id)
            {
                return BadRequest("Admin data is invalid.");
            }
            var existingAdmin = _adressService.TGetById(id);
            if (existingAdmin == null)
            {
                return NotFound($"Address with ID {id} not found.");
            }
            _adressService.TUpdate(address);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var address = _adressService.TGetById(id);
            if (address == null)
            {
                return NotFound($"Address with ID {id} not found.");
            }
            _adressService.TDelete(address);
            return NoContent();
        }
    }
}
