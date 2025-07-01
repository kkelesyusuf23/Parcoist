using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.Entity.Concrete;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var contacts = _contactService.TGetListAll();
            if (contacts == null || !contacts.Any())
            {
                return NotFound("No contacts found.");
            }
            return Ok(contacts);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _contactService.TGetById(id);
            if (contact == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }
            return Ok(contact);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest("Contact data is null.");
            }
            _contactService.TAdd(contact);
            return CreatedAtAction(nameof(Get), new { id = contact.ContactID }, contact);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Contact contact)
        {
            if (contact == null || contact.ContactID != id)
            {
                return BadRequest("Contact data is invalid.");
            }
            var existingContact = _contactService.TGetById(id);
            if (existingContact == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }
            _contactService.TUpdate(contact);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contact = _contactService.TGetById(id);
            if (contact == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }
            _contactService.TDelete(contact);
            return NoContent();
        }
    }
}