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
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Courses = await _context.Courses.Where(c => c.IsDeleted == false)
                .Take(12)
                .OrderByDescending(c => c.Id)
                .Include(c => c.CourseImage)
                .ToListAsync();
            CourseVM courseVM = new CourseVM
            {
                Courses = Courses
            };

            return View(courseVM);
        }
    }
}
