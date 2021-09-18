using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Areas.Admin.ViewModels;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> Categories = await _context.Categories.Where(c=>c.IsDeleted==false).ToListAsync();      
            return View(Categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid) return View(categoryVM);

            List<Category> Categories = await _context.Categories.Where(c=>c.IsDeleted==false).ToListAsync();

            bool categoryExists = Categories.Exists(c => c.Name == categoryVM.Name);

            if (categoryExists)
            {
                ModelState.AddModelError("", "Category already exists");
                return View(categoryVM);
            }

            Category category = new Category { Name = categoryVM.Name, IsDeleted=false };

            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.Where(c=>c.IsDeleted==false).FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            category.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await _context.Categories.Where(c=>c.IsDeleted==false).FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category category)
        {
            if (!ModelState.IsValid) return View(category);
            var existingCategory = await _context.Categories.Where(c=>c.IsDeleted==false).FirstOrDefaultAsync(c => c.Id == category.Id);
            if (category == null) return NotFound();
            var categoryExists = await _context.Categories.FirstOrDefaultAsync(c => c.Name == category.Name);

            if (categoryExists!=null)
            {
                ModelState.AddModelError("", "Category already exists");
                return View(category);
            }
            existingCategory.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
