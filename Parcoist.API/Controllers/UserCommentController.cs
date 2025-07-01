using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.Entity.Concrete;
using Parcoist.UI.Entities;

namespace Parcoist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentController : ControllerBase
    {
        private readonly IUserCommentService _userCommentService;

        public UserCommentController(IUserCommentService userCommentService)
        {
            _userCommentService = userCommentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var userComment = _userCommentService.TGetListAll();
            if (userComment == null || !userComment.Any())
            {
                return NotFound("No userComment found");
            }
            return Ok(userComment);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userComment = _userCommentService.TGetById(id);
            if (userComment == null)
            {
                return NotFound($"userComment with ID {id} not found.");
            }
            return Ok(userComment);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserComment userComment)
        {
            if (userComment == null)
            {
                return BadRequest("userComment data is null.");
            }
            _userCommentService.TAdd(userComment);
            return CreatedAtAction(nameof(Get), new { id = userComment.UserCommentID }, userComment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserComment userComment)
        {
            if (userComment == null || userComment.UserCommentID != id)
            {
                return BadRequest("userComment data is invalid.");
            }
            var existinguserCommentRequest = _userCommentService.TGetById(id);
            if (existinguserCommentRequest == null)
            {
                return NotFound($"userComment with ID {id} not found.");
            }
            _userCommentService.TUpdate(userComment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userComment = _userCommentService.TGetById(id);
            if (userComment == null)
            {
                return NotFound($"userComment with ID {id} not found.");
            }
            _userCommentService.TDelete(userComment);
            return NoContent();
        }
    }
}
