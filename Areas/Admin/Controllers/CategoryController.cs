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
            List<Category> Categories = await _context.Categories.ToListAsync();
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.Names = new List<string>();
            foreach (var category in Categories)
            {
                categoryVM.Names.Add(category.Name);
            }
            return View(categoryVM);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid) return View(categoryVM);

            List<Category> Categories = await _context.Categories.ToListAsync();

            bool categoryExists = Categories.Exists(c => c.Name == categoryVM.Name);

            if (categoryExists)
            {
                ModelState.AddModelError("", "Category already exists");
                return View(categoryVM);
            }

            Category category = new Category { Name = categoryVM.Name };

            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
