using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Controllers
{
    public class NewstellerController : Controller
    {
        public AppDbContext _context { get; }
        public NewstellerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Subscribe(Subscriber subscriber)
        {
            if (!ModelState.IsValid) return View(subscriber);
            _context.Subscribers.Add(subscriber);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
