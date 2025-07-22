using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcoist.Business.Abstract;
using Parcoist.DTO.CategoryDtos;
using Parcoist.DTO.LogoDtos;
using Parcoist.Entity.Concrete;
using Parcoist.UI.Entities;

namespace Parcoist.UI.Controllers
{
    public class LogoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogoService _logoService;

        public LogoController(IWebHostEnvironment webHostEnvironment, ILogoService logoService)
        {
            _webHostEnvironment = webHostEnvironment;
            _logoService = logoService;
        }

        public IActionResult Index()
        {
            var logos = _logoService.TGetListAll();
            return View(logos);
        }


        public IActionResult Delete(int id)
        {
            var value = _logoService.TGetById(id);
            value.LogoStatus = false;
            _logoService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var value = _logoService.TGetById(id);
            if (value != null)
            {
                _logoService.TDelete(value);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateLogoDto dto, IFormFile logoFile)
        {
            string imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "assest/images/logo");

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

                dto.LogoImage = "assest/images/logo/" + imageFileName1;
            }

            Logo logo = new Logo()
            {
                LogoImage = dto.LogoImage,
                LogoTitle = dto.LogoTitle,
                LogoLink = dto.LogoLink,
                LogoDate = DateTime.Now,
                LogoStatus = false
            };
            _logoService.TAdd(logo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _logoService.TGetById(id);

            var dto = new UpdateLogoDto
            {
                LogoImage = value.LogoImage,
                LogoID = value.LogoID,
                LogoTitle = value.LogoTitle,
                LogoLink = value.LogoLink,
            };
            ViewBag.LogoImage = value.LogoImage; // Eski logo yolunu ViewBag ile yolla


            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateLogoDto p, IFormFile logoFile)
        {
            string imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "assest/images/logo");

            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            var existingProduct = _logoService.TGetById(p.LogoID);
            if (existingProduct == null)
            {
                return NotFound();
            }

            if (logoFile != null)
            {
                if (!string.IsNullOrEmpty(existingProduct.LogoImage) && System.IO.File.Exists(Path.Combine(_webHostEnvironment.WebRootPath, existingProduct.LogoImage)))
                {
                    System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, existingProduct.LogoImage));
                }

                string imageExtension = Path.GetExtension(logoFile.FileName);
                string imageFileName = "i" + Guid.NewGuid().ToString() + imageExtension;
                string imagePath = Path.Combine(imageFolderPath, imageFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await logoFile.CopyToAsync(stream);
                }

                existingProduct.LogoImage = "assest/images/logo/" + imageFileName;
            }

            existingProduct.LogoTitle = p.LogoTitle;
            existingProduct.LogoLink = p.LogoLink;
            existingProduct.LogoDate = DateTime.Now;
            existingProduct.LogoStatus = false; 




            _logoService.TUpdate(existingProduct);

            return RedirectToAction("Index");
        }
    }
}
