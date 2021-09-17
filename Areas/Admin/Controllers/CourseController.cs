using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Areas.Admin.Helpers;
using EduHome.Areas.Admin.ViewModels;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CourseController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            //List<Course> Courses = _context.Courses.Include(c => c.CourseImage).ThenInclude(c=>c.)
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

            var photo = courseAdminVM.Photo;

            if (!FileHelper.CheckContent(photo.ContentType, "image/"))
            {
                ModelState.AddModelError("Photo", "Please select image format");
                return View(courseAdminVM);
            }

            if (!FileHelper.CheckLength(photo.Length, 200))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                return View(courseAdminVM);
            }

            FileHelper.CreateFile(photo.FileName, _env.WebRootPath, "img", photo);

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
                Fee = courseAdminVM.Fee,
                CourseImage = new CourseImage { Photo = FileHelper.UniqueFileName }
            };

            _context.Courses.Add(course);

            _context.SaveChanges();

            foreach (var categoryInput in courseAdminVM.CategoriesInput)
            {
                Category category = Categories.Find(c => c.Name == categoryInput);
                CourseCategory courseCategory = new CourseCategory { CategoryId = category.Id, CourseId = course.Id };
                _context.CourseCategories.Add(courseCategory);
                _context.SaveChanges();
            }
           
            return RedirectToAction(nameof(Index));
        }
    }
}
