using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Areas.Admin.ViewModels;
using EduHome.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EduHome.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contact = _context.Contact.ToList().ElementAt(0);

            return View(contact);
        }

        public IActionResult EditContact()
        {
            var contact = _context.Contact.ToList().ElementAt(0);

            ContactVM contactVM = new ContactVM
            {
                Address = contact.Address,
                Phone1 = contact.Phone1,
                Phone2 = contact.Phone2,
                WebSite = contact.WebSite,
                Email = contact.Email
            };

            return View(contactVM);
        }

        [HttpPost]
        public IActionResult EditContact(ContactVM contactVM)
        {
            if (!ModelState.IsValid) return View(contactVM);

            var contact = _context.Contact.ToList().ElementAt(0);

            contact.Address = contactVM.Address;
            contact.Phone1 = contactVM.Phone1;
            contact.Phone2 = contactVM.Phone2;
            contact.Email = contactVM.Email;
            contact.WebSite = contactVM.WebSite;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
