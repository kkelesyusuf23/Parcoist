using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcoist.Business.Abstract;
using Parcoist.DTO.CategoryDtos;
using Parcoist.DTO.UserCommentDtos;
using Parcoist.Entity.Concrete;
using Parcoist.UI.Entities;

namespace Parcoist.UI.Controllers
{
    public class UserCommentController : Controller
    {
        private readonly IProductCommentService _userCommentService;
        private readonly IProductService _productService;
        public UserCommentController(IProductCommentService userCommentService, IProductService productService)
        {
            _userCommentService = userCommentService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            // Kullanıcı giriş yapmış mı kontrol et
            var userId = HttpContext.Session.GetInt32("UserID");

            if (userId == null)
            {
                // Giriş yapılmamışsa login sayfasına yönlendir
                return RedirectToAction("Login", "Auth");
            }
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "SuperAdmin")
            {
                var con = _userCommentService.TGetListAll().Where(x => x.IsActive).ToList();
                return View(con);
            }
            var userComments = _userCommentService.TGetListAll();
            return View(userComments);
        }

        public IActionResult Delete(int id)
        {
            var value = _userCommentService.TGetById(id);
            value.IsActive = false;
            _userCommentService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "SuperAdmin")
            {
                return RedirectToAction("Index");
            }
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
            
            ProductComment userComment = new ProductComment
            {
                //UserID = dto.UserID,
                UserName = "Default",
                ProductId = dto.ProductID,
                CommentText = dto.Comment,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,


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
                username = value.UserName,
                //UserID = value.UserID,
                ProductID = value.ProductId,
                Comment = value.CommentText,
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
            existingComment.ProductId = p.ProductID;
            existingComment.CommentText = p.Comment;
            existingComment.UpdatedAt = DateTime.Now;
            _userCommentService.TUpdate(existingComment);

            return RedirectToAction("Index");
        }
    }
}
