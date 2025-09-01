using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcoist.Business.Abstract;
using Parcoist.DTO.ProductDtos;
using Parcoist.Entity.Concrete;
using Parcoist.UI.Entities;
using Parcoist.UI.Helpers;
using Parcoist.UI.Models;

namespace Parcoist.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IProductVariantCombinationService _productVariantCombinationService;
        private readonly IProductCommentService _productCommentService;
        private static IActionLogService _actionLogService;
        private readonly IUserService _userService;


        public ProductController(
            IWebHostEnvironment webHostEnvironment, 
            IProductService productService, 
            IBrandService brandService, 
            ICategoryService categoryService, 
            IProductVariantCombinationService productVariantCombinationService, 
            IProductCommentService productCommentService, 
            IUserService userService,
            IActionLogService actionLogService)
        {
            _webHostEnvironment = webHostEnvironment;
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
            _productVariantCombinationService = productVariantCombinationService;
            _productCommentService = productCommentService;
            _userService = userService;
            _actionLogService = actionLogService;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "SuperAdmin")
            {
                var con = _productService.TGetListAll().Where(x => x.IsActive).ToList();
                return View(con);
            }
            var products = _productService.TGetListAll();
            return View(products);
        }

        public IActionResult Delete(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var product = _productService.TGetById(id);
            if (product != null)
            {
                product.IsActive = false;
                _productService.TUpdate(product);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {

            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "SuperAdmin")
            {
                return RedirectToAction("Index");
            }
            var product = _productService.TGetById(id);
            if (product != null)
            {
                _productService.TDelete(product);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var categories = _categoryService.TGetListAll();
            if (categories != null)
                ViewBag.Categories = categories
                    .Select(c => new SelectListItem { Value = c.CategoryID.ToString(), Text = c.CategoryName })
                    .ToList();
            else
                ViewBag.Categories = new List<SelectListItem>();

            var brands = _brandService.TGetListAll();
            if (brands != null)
                ViewBag.Brands = brands
                    .Select(b => new SelectListItem { Value = b.BrandID.ToString(), Text = b.Name })
                    .ToList();
            else
                ViewBag.Brands = new List<SelectListItem>();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDto dto)
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            Product product = new Product()
            {
                SKU = dto.SKU,
                ModelNo = dto.ModelNo,
                Name = dto.Name,
                CategoryID = dto.CategoryID,
                BasePrice = dto.BasePrice,
                CostPrice = dto.CostPrice,
                DiscountedPrice = dto.DiscountedPrice,
                Stock = dto.Stock,
                Description = dto.Description,
                Link1 = dto.Link1,
                Link2 = dto.Link2,
                Link3 = dto.Link3,
                IsFeatured = dto.IsFeatured,
                BrandID = dto.BrandID,
                CreatedAt = DateTime.Now,
                UptatedAt = DateTime.Now,
                IsActive = true,
                Slug = dto.Name.Replace(" ", "-").ToLower()
            };
            _productService.TAdd(product);
            ActionLogHelper.LogAction(_actionLogService, "Yeni ürün ekleme", dto.Name, userId);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var value = _productService.TGetById(id);
            if (value == null)
            {
                return RedirectToAction("Index"); // Ürün bulunamazsa yönlendir.
            }

            var categories = _categoryService.TGetListAll();
            if (categories != null)
                ViewBag.Categories = categories
                    .Select(c => new SelectListItem { Value = c.CategoryID.ToString(), Text = c.CategoryName })
                    .ToList();
            else
                ViewBag.Categories = new List<SelectListItem>();

            var brands = _brandService.TGetListAll();
            if (brands != null)
                ViewBag.Brands = brands
                    .Select(b => new SelectListItem { Value = b.BrandID.ToString(), Text = b.Name })
                    .ToList();
            else
                ViewBag.Brands = new List<SelectListItem>();

            var dto = new UpdateProductDto
            {
                SKU = value.SKU,
                ModelNo = value.ModelNo,
                Name = value.Name,
                CategoryID = value.CategoryID,
                BasePrice = value.BasePrice,
                CostPrice = value.CostPrice,
                DiscountedPrice = value.DiscountedPrice,
                Stock = value.Stock,
                Description = value.Description,
                Link1 = value.Link1,
                Link2 = value.Link2,
                Link3 = value.Link3,
                IsFeatured = value.IsFeatured,
                IsActive = value.IsActive,
                BrandID = value.BrandID,
                ProductID = value.ProductID,
            };

            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto p)
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var user = _userService.TGetById((int)userId);
            var updateProduct = new Product
            {
                ProductID = p.ProductID,
                SKU = p.SKU,
                ModelNo = p.ModelNo,
                Name = p.Name,
                CategoryID = p.CategoryID,
                BasePrice = p.BasePrice,
                CostPrice = p.CostPrice,
                DiscountedPrice = p.DiscountedPrice,
                Stock = p.Stock,
                Description = p.Description,
                Link1 = p.Link1,
                Link2 = p.Link2,
                Link3 = p.Link3,
                IsFeatured = p.IsFeatured,
                IsActive = p.IsActive,
                BrandID = p.BrandID,
                UptatedAt = DateTime.Now,
                Slug = p.Name.Replace(" ", "-").ToLower()
            };

            ActionLogHelper.LogAction(_actionLogService, "Ürün güncelleme", p.Name, user.UserID);


            _productService.TUpdate(updateProduct);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _productService.TGetProductsWithAllRelations()
                .FirstOrDefault(p => p.ProductID == id);

            if (product == null)
                return NotFound();

            // ProductImages
            var productImages = product.ProductImages.ToList();

            // VariantCombinations + içindeki ProductVariantValues ve onların FeatureType ve FeatureValue ilişkileri
            var variantCombinations = _productVariantCombinationService.TGetProductVariantWithProductAndValues(id);

            var comments = _productCommentService.TGetListAll().Where(x => x.ProductId == id).ToList();

            var viewModel = new ProductDetailViewModel
            {
                Product = product,
                ProductImages = productImages,
                VariantCombinations = variantCombinations,
                ProductComments = comments
            };

            // Log kaydı
            ActionLogHelper.LogAction(_actionLogService, "Ürün incelemesi", product.Name,null);

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult AddComment(AddProductCommentViewModel model)
        {
            var randomsayi = new Random();
            if (ModelState.IsValid)
            {
                var comment = new ProductComment
                {
                    ProductId = model.ProductID,
                    CommentText = model.CommentText,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsActive = true,
                    UserName = "User" + randomsayi.Next(),
                    //CreatedDate = DateTime.Now
                };

                _productCommentService.TAdd(comment);
                var productName = _productService.TGetById(comment.ProductId)?.Name ?? "Ürün bulunamadı";
                ActionLogHelper.LogAction(_actionLogService, "Ürün yorum ekleme", productName,0);
                return RedirectToAction("Details", new { id = model.ProductID });
            }

            // Hata olursa tekrar product detayına dön
            return RedirectToAction("Details", new { id = model.ProductID });
        }


    }
}
