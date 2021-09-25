using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Areas.Admin.Helpers;
using EduHome.Areas.Admin.ViewModels;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
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
            List<Course> Courses = _context.Courses.Where(c=>c.IsDeleted==false)
                .Include(c => c.CourseImage)
                .Include(c => c.CourseCategories)
                .ThenInclude(c => c.Category)
                .ToList();
            return View(Courses);
        }

        public async Task<IActionResult> CreateCourse()
        {
            CourseAdminVM ca = new CourseAdminVM();
            ca.Languages = new List<LanguageVM>();
            ca.Categories = new List<CategoryVM>();
            List<Category> Categories = await _context.Categories.Where(c=>c.IsDeleted==false).ToListAsync();

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
            List<Category> Categories = await _context.Categories.Where(c=>c.IsDeleted == false).ToListAsync();

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

            if(photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be empty");
                return View(ca);
            }

            if (!FileHelper.CheckContent(photo.ContentType, "image/"))
            {
                ModelState.AddModelError("Photo", "Please select image format");
                return View(ca);
            }

            if (!FileHelper.CheckLength(photo.Length, 200))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                return View(ca);
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

        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            course.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditCourse(int id)
        {
            var course = await _context.Courses.Where(c=>c.IsDeleted==false)
                .Include(c=>c.CourseImage)
                .Include(c=>c.CourseCategories)
                .ThenInclude(c=>c.Category)
                .FirstOrDefaultAsync(c=>c.Id == id);

            if (course == null) return NotFound();

            CourseAdminVM ca = new CourseAdminVM();
            ca.Languages = new List<LanguageVM>();
            ca.Categories = new List<CategoryVM>();
            ca.Course = course;
            ca.StartDate = course.StartDate;
            List<Category> Categories = await _context.Categories.Where(c=>c.IsDeleted == false).ToListAsync();

            foreach (var language in Enum.GetValues(typeof(Languages)))
            {
                ca.Languages.Add(new LanguageVM { Name = language.ToString() });
            }

            foreach (var category in Categories)
            {
                ca.Categories.Add(new CategoryVM { Name = category.Name });
            }

            List<CategoryVM> existingCategories = new List<CategoryVM>();
            foreach (var category in course.CourseCategories)
            {
                CategoryVM categoryVM = new CategoryVM { Name = category.Category.Name };
                existingCategories.Add(categoryVM);
            }

            var filteredList = new List<CategoryVM>();
            foreach (var item in ca.Categories.ToList())
            {
                if (existingCategories.FirstOrDefault(c => c.Name == item.Name) != null)
                {
                    ca.Categories.Remove(item);
                }
            }
            filteredList = ca.Categories;

            ViewBag.Categories = filteredList;

            return View(ca);
        }

        [HttpPost]
        public async Task<IActionResult> EditCourse(CourseAdminVM courseAdminVM)
        {

            CourseAdminVM ca = new CourseAdminVM();
            ca.Languages = new List<LanguageVM>();
            ca.Categories = new List<CategoryVM>();
            List<Category> Categories = await _context.Categories.Where(c=>c.IsDeleted == false).ToListAsync();

            foreach (var language in Enum.GetValues(typeof(Languages)))
            {
                ca.Languages.Add(new LanguageVM { Name = language.ToString() });
            }

            foreach (var category in Categories)
            {
                ca.Categories.Add(new CategoryVM { Name = category.Name });
            }

            var course = await _context.Courses.Where(c => c.IsDeleted == false)
                .Include(c => c.CourseImage)
                .Include(c => c.CourseCategories)
                .ThenInclude(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == courseAdminVM.CourseId);
            if (course == null) return NotFound();
            ca.Course = course;
            List<CategoryVM> existingCategories = new List<CategoryVM>();
            foreach (var category in course.CourseCategories)
            {
                CategoryVM categoryVM = new CategoryVM { Name = category.Category.Name };
                existingCategories.Add(categoryVM);
            }

            var filteredList = new List<CategoryVM>();
            foreach (var item in ca.Categories.ToList())
            {
                if (existingCategories.FirstOrDefault(c => c.Name == item.Name) != null)
                {
                    ca.Categories.Remove(item);
                }
            }
            filteredList = ca.Categories;

            ViewBag.Categories = filteredList;

            

            

            if (!ModelState.IsValid) return View(ca);
            
            var existingImage = await _context.CourseImage.FirstOrDefaultAsync(ci=>ci.CourseId==course.Id);
            if (existingImage == null) return NotFound();

            var photo = courseAdminVM.Photo;

            if (photo != null)
            {
                if (!FileHelper.CheckContent(photo.ContentType, "image/"))
                {
                    ModelState.AddModelError("Photo", "Please select image format");
                    return View(ca);
                }

                if (!FileHelper.CheckLength(photo.Length, 200))
                {
                    ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                    return View(ca);
                }

                FileHelper.DeleteFile(existingImage.Photo, _env.WebRootPath, "img");
                FileHelper.CreateFile(courseAdminVM.Photo.FileName, _env.WebRootPath, "img", courseAdminVM.Photo);
                existingImage.Photo = FileHelper.UniqueFileName;
            }
            

            var existingCourseCategories = await _context.CourseCategories.Select(x=>x).Where(c=>c.CourseId == course.Id).ToListAsync();
            foreach (var coursecategory in existingCourseCategories)
            {
                _context.CourseCategories.Remove(coursecategory);
            }

            foreach (var categoryInput in courseAdminVM.CategoriesInput)
            {
                Category category = Categories.Find(c => c.Name == categoryInput);
                CourseCategory courseCategory = new CourseCategory { CategoryId = category.Id, CourseId = course.Id };
                _context.CourseCategories.Add(courseCategory);
            }

            course.Name = courseAdminVM.Name;
            course.Title = courseAdminVM.Title;
            course.Description = courseAdminVM.Description;
            course.Certification = courseAdminVM.Certification;
            course.ApplicationRule = courseAdminVM.ApplicationRule;
            course.Assesment = courseAdminVM.Assesment;
            course.ClassDuration = courseAdminVM.ClassDuration;
            course.Duration = courseAdminVM.Duration;
            course.StartDate = courseAdminVM.StartDate;
            course.SkillLevel = courseAdminVM.SkillLevel;
            course.Language = courseAdminVM.Language;
            course.StudentCapacity = courseAdminVM.StudentCapacity;
            course.Fee = courseAdminVM.Fee;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewCourse(int id)
        {
            var course = _context.Courses.Where(c => c.IsDeleted == false)
                .Include(c => c.CourseCategories)
                .ThenInclude(c => c.Category)
                .Include(c => c.CourseImage)
                .FirstOrDefault(c => c.Id == id);

            return View(course);
        }
    }
}
