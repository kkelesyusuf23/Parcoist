using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcoist.Business.Abstract;
using Parcoist.DTO.CategoryDtos;
using Parcoist.DTO.ProductImage;
using Parcoist.UI.Entities;

namespace Parcoist.UI.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductImageService _productImageService;
        private readonly IProductService _productService;

        public ProductImageController(IWebHostEnvironment webHostEnvironment, IProductImageService productImageService, IProductService productService)
        {
            _webHostEnvironment = webHostEnvironment;
            _productImageService = productImageService;
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
                var con = _productImageService.TGetListAll().Where(x => x.IsActive).ToList();
                return View(con);
            }
            var productImages = _productImageService.TGetListAll();
            return View(productImages);
        }

        public IActionResult Delete(int id)
        {
            var value = _productImageService.TGetById(id);
            value.IsActive = false;
            _productImageService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "SuperAdmin")
            {
                return RedirectToAction("Index");
            }
            var value = _productImageService.TGetById(id);
            if (value != null)
            {
                _productImageService.TDelete(value);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var parentProduct = _productService.TGetListAll(); 
            ViewBag.ParentProduct = new SelectList(parentProduct, "ProductID", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductImageDto dto, IFormFile logoFile)
        {
            string imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "assest/images/productimage");

            // Check if the folder exists, if not, create it  
            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            // Check and upload the image file  
            if (logoFile != null)
            {
                string imageExtension1 = Path.GetExtension(logoFile.FileName);
                string imageFileName1 = "i" + Guid.NewGuid().ToString() + imageExtension1;
                string imagePath1 = Path.Combine(imageFolderPath, imageFileName1);

                using (var stream = new FileStream(imagePath1, FileMode.Create))
                {
                    await logoFile.CopyToAsync(stream);
                }

                dto.ImagePath = "assest/images/productimage/" + imageFileName1;
            }

            ProductImage productImage = new ProductImage
            {
                ProductID = dto.ProductID,
                ImagePath = dto.ImagePath,
                Order = dto.Order,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };
            _productImageService.TAdd(productImage);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _productImageService.TGetById(id);

            var dto = new UpdateProductImageDto
            {
                ProductImageID = id,
                ProductID = value.ProductID,
                ImagePath = value.ImagePath,
                Order = value.Order
            };

            var parentProduct = _productService.TGetListAll();
            ViewBag.ParentProduct = new SelectList(parentProduct, "ProductID", "Name");
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductImageDto p, IFormFile logoFile)
        {
            string imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "assest/images/productimage");

            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            var existingProduct = _productImageService.TGetById(p.ProductImageID);
            if (existingProduct == null)
            {
                return NotFound();
            }

            if (logoFile != null)
            {
                if (!string.IsNullOrEmpty(existingProduct.ImagePath) && System.IO.File.Exists(Path.Combine(_webHostEnvironment.WebRootPath, existingProduct.ImagePath)))
                {
                    System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, existingProduct.ImagePath));
                }

                string imageExtension = Path.GetExtension(logoFile.FileName);
                string imageFileName = "i" + Guid.NewGuid().ToString() + imageExtension;
                string imagePath = Path.Combine(imageFolderPath, imageFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await logoFile.CopyToAsync(stream);
                }

                existingProduct.ImagePath = "assest/images/productimage/" + imageFileName;
            }

            existingProduct.ProductID = p.ProductID;
            existingProduct.Order = p.Order;
            _productImageService.TUpdate(existingProduct);


            return RedirectToAction("Index");
        }
    }
}
