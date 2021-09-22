using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Sliders = await _context.Sliders.ToListAsync();
            var Courses = await _context.Courses.Where(c => c.IsDeleted == false)
                .OrderByDescending(s=>s.Id)
                .Take(3)
                .Include(c => c.CourseImage).ToListAsync();
            var Events = await _context.Events.Where(e => e.IsDeleted == false)
                .Include(e => e.EventImage)
                .OrderByDescending(e => e.Id)
                .Take(4)
                .ToListAsync();

            HomeVM homeVM = new HomeVM
            {
                Sliders = Sliders,
                Courses = Courses,
                Events = Events
            };

            return View(homeVM);
        }
    }
}
