using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var admins = _adminService.TGetListAll();
            if (admins == null || !admins.Any())
            {
                return NotFound("No admins found.");
            }
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var admin = _adminService.TGetById(id);
            if (admin == null)
            {
                return NotFound($"Admin with ID {id} not found.");
            }
            return Ok(admin);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Admin admin)
        {
            if (admin == null)
            {
                return BadRequest("Admin data is null.");
            }
            _adminService.TAdd(admin);
            return CreatedAtAction(nameof(GetById), new { id = admin.ID }, admin);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Admin admin)
        {
            if (admin == null || admin.ID != id)
            {
                return BadRequest("Admin data is invalid.");
            }
            var existingAdmin = _adminService.TGetById(id);
            if (existingAdmin == null)
            {
                return NotFound($"Admin with ID {id} not found.");
            }
            _adminService.TUpdate(admin);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var admin = _adminService.TGetById(id);
            if (admin == null)
            {
                return NotFound($"Admin with ID {id} not found.");
            }
            _adminService.TDelete(admin);
            return NoContent();
        }
    }
}
