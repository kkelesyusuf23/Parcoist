using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.Entity.Concrete;
using Parcoist.UI.Models;

namespace Parcoist.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactService _contactService;

        public HomeController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactViewModel model)
        {
            var contact = new Contact
            {
                ContactName = model.ContactName,
                ContactEmail = model.ContactEmail,
                ContactSubject = model.ContactSubject,
                ContactMessage = model.ContactMessage,
                ContactPhone = model.ContactPhone,
                ContactDate = DateTime.Now,
                ContactStatus = false
            };

            _contactService.TAdd(contact);
            return View();
        }
    }
}
