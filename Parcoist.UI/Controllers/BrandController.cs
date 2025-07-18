using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcoist.Business.Abstract;
using Parcoist.DTO.BrandDtos;
using Parcoist.UI.Entities;

namespace Parcoist.UI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BrandController(IBrandService brandService, IWebHostEnvironment webHostEnvironment)
        {
            _brandService = brandService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var brands = _brandService.TGetListAll();
            return View(brands);
        }

        public IActionResult DeleteBrand(int id)
        {
            var value = _brandService.TGetById(id);
            value.IsActive = false;
            //if (!string.IsNullOrEmpty(value.LogoURL))
            //{
            //    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, value.LogoURL.TrimStart('~', '/'));
            //    if (System.IO.File.Exists(imagePath))
            //    {
            //        System.IO.File.Delete(imagePath);
            //    }
            //}

            _brandService.TUpdate(value);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveBrand(int id)
        {
            var value = _brandService.TGetById(id);
            if (value != null)
            {
                _brandService.TDelete(value);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(CreateBrandDto dto, IFormFile logoFile)
        {
            string imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "assest/images/brand");

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

                dto.LogoURL = "assest/images/brand/" + imageFileName1;
            }

            Brand brand = new Brand()
            {
                LogoURL = dto.LogoURL,
                Name = dto.Name,
                Slug = dto.Name,
                Website = dto.Website,
                Description = dto.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = false
            };
            _brandService.TAdd(brand);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            var value = _brandService.TGetById(id);

            var dto = new UpdateBrandDto
            {
                BrandID = value.BrandID,
                Name = value.Name,
                LogoURL = value.LogoURL,
                Website = value.Website,
                Description = value.Description,
                IsActive = value.IsActive
            };
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto p, IFormFile logoFile)
        {
            string imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "assest/images/brand");

            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            var existingProduct = _brandService.TGetById(p.BrandID);
            if (existingProduct == null)
            {
                return NotFound();
            }

            if (logoFile != null)
            {
                if (!string.IsNullOrEmpty(existingProduct.LogoURL) && System.IO.File.Exists(Path.Combine(_webHostEnvironment.WebRootPath, existingProduct.LogoURL)))
                {
                    System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, existingProduct.LogoURL));
                }

                string imageExtension = Path.GetExtension(logoFile.FileName);
                string imageFileName = "i" + Guid.NewGuid().ToString() + imageExtension;
                string imagePath = Path.Combine(imageFolderPath, imageFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await logoFile.CopyToAsync(stream);
                }

                existingProduct.LogoURL = "assest/images/brand/" + imageFileName; 
            }

            existingProduct.Name = p.Name;
            existingProduct.Slug = p.Name;
            existingProduct.Website = p.Website;
            existingProduct.Description = p.Description;
            existingProduct.UpdatedAt = DateTime.Now;
            existingProduct.IsActive = p.IsActive;

            _brandService.TUpdate(existingProduct);

            return RedirectToAction("Index");
        }
    }
}