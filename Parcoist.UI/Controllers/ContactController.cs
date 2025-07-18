using Microsoft.AspNetCore.Mvc;
using Parcoist.Business.Abstract;
using Parcoist.DTO.ContactDtos;
using Parcoist.Entity.Concrete;

namespace Parcoist.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            var contacts = _contactService.TGetListAll();
            return View(contacts);
        }

        public IActionResult Delete(int id)
        {
            var value = _contactService.TGetById(id);
            value.ContactStatus = false;
            _contactService.TUpdate(value);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var value = _contactService.TGetById(id);
            if (value != null)
            {
                _contactService.TDelete(value);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreateContactDto contact)
        {
            if (ModelState.IsValid)
            {
                Contact newContact = new Contact
                {
                    ContactName = contact.ContactName,
                    ContactEmail = contact.ContactEmail,
                    ContactSubject = contact.ContactSubject,
                    ContactMessage = contact.ContactMessage,
                    ContactPhone = contact.ContactPhone,
                    ContactDate = DateTime.Now,
                    ContactStatus = false
                };
                _contactService.TAdd(newContact);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var contact = _contactService.TGetById(id);
            if (contact == null) return View();

            var dto = new UpdateContactDto
            {
                ContactID = contact.ContactID,
                ContactName = contact.ContactName,
                ContactEmail = contact.ContactEmail,
                ContactPhone = contact.ContactPhone,
                ContactSubject = contact.ContactSubject,
                ContactMessage = contact.ContactMessage
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Update(UpdateContactDto contactDto)
        {
            if (ModelState.IsValid)
            {
                var contact = _contactService.TGetById(contactDto.ContactID);
                if (contact == null)
                {
                    return View();
                }
                contact.ContactName = contactDto.ContactName;
                contact.ContactEmail = contactDto.ContactEmail;
                contact.ContactSubject = contactDto.ContactSubject;
                contact.ContactMessage = contactDto.ContactMessage;
                contact.ContactPhone = contactDto.ContactPhone;
                contact.ContactDate = DateTime.Now;
                _contactService.TUpdate(contact);
                return RedirectToAction("Index");
            }
            return View(contactDto);
        }
    }
}
