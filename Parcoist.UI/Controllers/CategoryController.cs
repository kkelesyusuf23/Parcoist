using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcoist.Business.Abstract;
using Parcoist.DTO.BrandDtos;
using Parcoist.DTO.CategoryDtos;
using Parcoist.UI.Entities;

namespace Parcoist.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.TGetListAll();
            return View(categories);
        }

        public IActionResult Delete(int id)
        {
            var value = _categoryService.TGetById(id);
            value.IsActive = false;
            _categoryService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value != null)
            {
                _categoryService.TDelete(value);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var parentCategories = _categoryService.TGetListAll(); // veya uygun servis metodu
            ViewBag.ParentCategories = new SelectList(parentCategories, "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryDto dto, IFormFile logoFile)
        {
            string imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "assest/images/category");

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

                dto.CategoryImage = "assest/images/category/" + imageFileName1;
            }

            Category brand = new Category()
            {
                CategoryName = dto.CategoryName,
                CategoryDescription = dto.CategoryDescription,
                CategoryImage = dto.CategoryImage,
                ParentCategoryID = dto.ParentCategoryID,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Slug = dto.CategoryName.Replace(" ", "-").ToLower()
            };
            _categoryService.TAdd(brand);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _categoryService.TGetById(id);

            var dto = new UpdateCategoryDto
            {
                CategoryID = value.CategoryID,
                CategoryName = value.CategoryName,
                CategoryDescription = value.CategoryDescription,
                CategoryImage = value.CategoryImage,
                ParentCategoryID = value.ParentCategoryID,
                UpdatedAt = value.UpdatedAt,

            };

            var parentCategories = _categoryService.TGetListAll()
         .Where(c => c.CategoryID != id).ToList();
            ViewBag.ParentCategories = new SelectList(parentCategories, "CategoryID", "CategoryName");
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto p, IFormFile logoFile)
        {
            string imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "assest/images/category");

            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            var existingProduct = _categoryService.TGetById(p.CategoryID);
            if (existingProduct == null)
            {
                return NotFound();
            }

            if (logoFile != null)
            {
                if (!string.IsNullOrEmpty(existingProduct.CategoryImage) && System.IO.File.Exists(Path.Combine(_webHostEnvironment.WebRootPath, existingProduct.CategoryImage)))
                {
                    System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, existingProduct.CategoryImage));
                }

                string imageExtension = Path.GetExtension(logoFile.FileName);
                string imageFileName = "i" + Guid.NewGuid().ToString() + imageExtension;
                string imagePath = Path.Combine(imageFolderPath, imageFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await logoFile.CopyToAsync(stream);
                }

                existingProduct.CategoryImage = "assest/images/category/" + imageFileName;
            }

            existingProduct.CategoryName = p.CategoryName;
            existingProduct.CategoryDescription = p.CategoryDescription;
            existingProduct.ParentCategoryID = p.ParentCategoryID;
            existingProduct.UpdatedAt = DateTime.Now;
            existingProduct.Slug = p.CategoryName.Replace(" ", "-").ToLower();



            _categoryService.TUpdate(existingProduct);

            return RedirectToAction("Index");
        }

    }
}
