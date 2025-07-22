using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Parcoist.Business.Abstract;
using Parcoist.DTO.CategoryDtos;
using Parcoist.DTO.SliderDtos;
using Parcoist.Entity.Concrete;
using Parcoist.UI.Entities;

namespace Parcoist.UI.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderController(ISliderService sliderService, IWebHostEnvironment webHostEnvironment)
        {
            _sliderService = sliderService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var sliders = _sliderService.TGetListAll();
            return View(sliders);
        }

        public IActionResult Delete(int id)
        {
            var value = _sliderService.TGetById(id);
            value.SliderStatus = false;
            _sliderService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var value = _sliderService.TGetById(id);
            if (value != null)
            {
                _sliderService.TDelete(value);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateSliderDto dto, IFormFile logoFile)
        {
            string imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "assest/images/slider");

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

                dto.SliderImage = "assest/images/slider/" + imageFileName1;
            }

            Slider slider = new Slider
            {
                SliderTitle = dto.SliderTitle,
                SliderImage = dto.SliderImage,
                SliderLink = dto.SliderLink,
                SliderLinkTitle = dto.SliderLinkTitle,
                SliderDescription = dto.SliderDescription,
                SliderOrder = dto.SliderOrder,
                SliderStatus = true, 
            };
            _sliderService.TAdd(slider);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _sliderService.TGetById(id);

            var dto = new UpdateSliderDto
            {
                SliderID = value.SliderID,
                SliderTitle = value.SliderTitle,
                SliderImage = value.SliderImage,
                SliderLink = value.SliderLink,
                SliderLinkTitle = value.SliderLinkTitle,
                SliderDescription = value.SliderDescription,
                SliderOrder = value.SliderOrder,
                SliderStatus = value.SliderStatus

            };

            
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSliderDto p, IFormFile logoFile)
        {
            string imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "assest/images/slider");

            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            var existingProduct = _sliderService.TGetById(p.SliderID);
            if (existingProduct == null)
            {
                return NotFound();
            }

            if (logoFile != null)
            {
                if (!string.IsNullOrEmpty(existingProduct.SliderImage) && System.IO.File.Exists(Path.Combine(_webHostEnvironment.WebRootPath, existingProduct.SliderImage)))
                {
                    System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, existingProduct.SliderImage));
                }

                string imageExtension = Path.GetExtension(logoFile.FileName);
                string imageFileName = "i" + Guid.NewGuid().ToString() + imageExtension;
                string imagePath = Path.Combine(imageFolderPath, imageFileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await logoFile.CopyToAsync(stream);
                }

                existingProduct.SliderImage = "assest/images/slider/" + imageFileName;
            }

            existingProduct.SliderTitle = p.SliderTitle;
            existingProduct.SliderLink = p.SliderLink;
            existingProduct.SliderLinkTitle = p.SliderLinkTitle;
            existingProduct.SliderDescription = p.SliderDescription;
            existingProduct.SliderOrder = p.SliderOrder;
            existingProduct.SliderStatus = p.SliderStatus;




            _sliderService.TUpdate(existingProduct);

            return RedirectToAction("Index");
        }
    }
}
