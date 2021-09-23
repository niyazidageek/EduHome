using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace EduHome.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactVM contactVM)
        {
            if (!ModelState.IsValid) return View(contactVM);
            Message message = new Message
            {
                Name = contactVM.Name,
                Email = contactVM.Email,
                Text = contactVM.Message,
                Subject = contactVM.Subject
            };

            _context.Messages.Add(message);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
