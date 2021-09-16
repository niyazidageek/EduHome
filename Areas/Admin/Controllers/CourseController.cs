using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Areas.Admin.Helpers;
using EduHome.Areas.Admin.ViewModels;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateCourse()
        {
            CourseAdminVM ca = new CourseAdminVM();
            ca.Languages = new List<LanguageVM>();
            ca.Categories = new List<CategoryVM>();
            List<Category> Categories = await _context.Categories.ToListAsync();

            foreach (var language in Enum.GetValues(typeof(Languages)))
            {
                ca.Languages.Add(new LanguageVM { Name = language.ToString() });
            }

            foreach (var category in Categories)
            {
                ca.Categories.Add(new CategoryVM { Name = category.Name });
            }

            return View(ca);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseAdminVM courseAdminVM)
        {
            CourseAdminVM ca = new CourseAdminVM();
            ca.Languages = new List<LanguageVM>();
            ca.Categories = new List<CategoryVM>();
            List<Category> Categories = await _context.Categories.ToListAsync();

            foreach (var language in Enum.GetValues(typeof(Languages)))
            {
                ca.Languages.Add(new LanguageVM { Name = language.ToString() });
            }

            foreach (var category in Categories)
            {
                ca.Categories.Add(new CategoryVM { Name = category.Name });
            }

            if (!ModelState.IsValid)
            {
                return View(ca);
            }

            Course course = new Course
            {
                Name = courseAdminVM.Name,
                Title = courseAdminVM.Title,
                Description = courseAdminVM.Description,
                ApplicationRule = courseAdminVM.ApplicationRule,
                Certification = courseAdminVM.Certification,
                StartDate = courseAdminVM.StartDate,
                Duration = courseAdminVM.Duration,
                ClassDuration = courseAdminVM.ClassDuration,
                SkillLevel = courseAdminVM.SkillLevel,
                Language = courseAdminVM.Language,
                StudentCapacity = courseAdminVM.StudentCapacity,
                Assesment = courseAdminVM.Assesment,
                Fee = courseAdminVM.Fee
            };

            _context.Courses.Add(course);

            foreach (var categoryInput in courseAdminVM.Categories)
            {
                Category category = Categories.Find(c=>c.Name == categoryInput.Name);
                CourseCategory courseCategory = new CourseCategory
                {
                    Course = course,
                    Category = category
                };
                _context.CourseCategories.Add(courseCategory);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
