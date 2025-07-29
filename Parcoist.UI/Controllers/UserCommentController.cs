using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcoist.Business.Abstract;
using Parcoist.DTO.CategoryDtos;
using Parcoist.DTO.UserCommentDtos;
using Parcoist.UI.Entities;

namespace Parcoist.UI.Controllers
{
    public class UserCommentController : Controller
    {
        private readonly IUserCommentService _userCommentService;
        private readonly IProductService _productService;
        public UserCommentController(IUserCommentService userCommentService, IProductService productService)
        {
            _userCommentService = userCommentService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var userComments = _userCommentService.TGetListAll();
            return View(userComments);
        }

        public IActionResult Delete(int id)
        {
            var value = _userCommentService.TGetById(id);
            //value.IsActive = false;
            _userCommentService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var value = _userCommentService.TGetById(id);
            if (value != null)
            {
                _userCommentService.TDelete(value);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var parentProduct = _productService.TGetListAll();
            ViewBag.ProductList = new SelectList(parentProduct, "ProductID", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateUserCommentDto dto)
        {
            
            UserComment userComment = new UserComment
            {
                //UserID = dto.UserID,
                UserID = 1,
                ProductID = dto.ProductID,
                Comment = dto.Comment,
                Description = dto.Description,
                Date = DateTime.Now.ToString(),
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now


            };
            _userCommentService.TAdd(userComment);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _userCommentService.TGetById(id);

            var dto = new UpdateUserCommentDto
            {
                UserCommentID = value.UserCommentID,
                //UserID = value.UserID,
                UserID = 1,
                ProductID = value.ProductID,
                Comment = value.Comment,
                Description = value.Description,
            };

            var parentProduct = _productService.TGetListAll();
            ViewBag.ParentProduct = new SelectList(parentProduct, "ProductID", "Name");
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserCommentDto p)
        {


            var existingComment = _userCommentService.TGetById(p.UserCommentID);

            //existingComment.UserID = p.UserID;
            existingComment.UserID = 1;
            existingComment.ProductID = p.ProductID;
            existingComment.Comment = p.Comment;
            existingComment.Description = p.Description;
            existingComment.Date = DateTime.Now.ToString();
            _userCommentService.TUpdate(existingComment);

            return RedirectToAction("Index");
        }
    }
}
