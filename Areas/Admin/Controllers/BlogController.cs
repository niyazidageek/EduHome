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
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Blog> Blogs = await _context.Blogs.Where(b => b.IsDeleted == false)
                .Include(b => b.BlogImage)
                .Include(b => b.BlogCategories)
                .ThenInclude(b => b.Category)
                .ToListAsync();

            return View(Blogs);
        }

        public async Task<IActionResult> CreateBlog()
        {
            BlogVM bvm = new BlogVM();
            bvm.Categories = new List<CategoryVM>();
            List<Category> Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();

            foreach (var category in Categories)
            {
                bvm.Categories.Add(new CategoryVM { Name = category.Name });
            }

            return View(bvm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogVM blogVM)
        {
            BlogVM bvm = new BlogVM();
            bvm.Categories = new List<CategoryVM>();
            List<Category> Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();

            foreach (var category in Categories)
            {
                bvm.Categories.Add(new CategoryVM { Name = category.Name });
            }

            if (!ModelState.IsValid) return View(bvm);

            var photo = blogVM.Photo;

            if (photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be empty");
                return View(bvm);
            }

            if (!FileHelper.CheckContent(photo.ContentType, "image/"))
            {
                ModelState.AddModelError("Photo", "Please select image format");
                return View(bvm);
            }

            if (!FileHelper.CheckLength(photo.Length, 200))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                return View(bvm);
            }

            FileHelper.CreateFile(photo.FileName, _env.WebRootPath, "img", photo);

            Blog blog = new Blog
            {
                Name = blogVM.Name,
                AuthorFullName = blogVM.AuthorFullName,
                PostDate = blogVM.PostDate,
                Content = blogVM.Content,
                BlogImage = new BlogImage { Photo = FileHelper.UniqueFileName},
                IsDeleted = false
            };

            _context.Blogs.Add(blog);
            _context.SaveChanges();

            foreach (var categoryInput in blogVM.CategoriesInput)
            {
                Category category = Categories.Find(c => c.Name == categoryInput);
                BlogCategory blogCategory = new BlogCategory { CategoryId = category.Id, BlogId = blog.Id };
                _context.BlogCategories.Add(blogCategory);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditBlog(int id)
        {
            var blog = await _context.Blogs.Where(b => b.IsDeleted == false)
                .Include(b => b.BlogImage)
                .Include(b => b.BlogCategories)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blog == null) return NotFound();

            BlogVM bvm = new BlogVM();
            bvm.Blog = blog;
            bvm.PostDate = blog.PostDate;
            bvm.BlogId = blog.Id;
            bvm.Categories = new List<CategoryVM>();
            List<Category> Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();

            foreach (var category in Categories)
            {
                bvm.Categories.Add(new CategoryVM { Name = category.Name });
            }

            List<CategoryVM> existingCategories = new List<CategoryVM>();
            foreach (var category in blog.BlogCategories)
            {
                CategoryVM categoryVM = new CategoryVM { Name = category.Category.Name };
                existingCategories.Add(categoryVM);
            }

            var filteredListCategories = new List<CategoryVM>();
            foreach (var item in bvm.Categories.ToList())
            {
                if (existingCategories.FirstOrDefault(c => c.Name == item.Name) != null)
                {
                    bvm.Categories.Remove(item);
                }
            }
            filteredListCategories = bvm.Categories;

            ViewBag.Categories = filteredListCategories;

            return View(bvm);
        }

        [HttpPost]
        public async Task<IActionResult> EditBlog(BlogVM blogVM)
        {
            var blog = await _context.Blogs.Where(b => b.IsDeleted == false)
                .Include(b => b.BlogImage)
                .Include(b => b.BlogCategories)
                .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == blogVM.BlogId);

            if (blog == null) return NotFound();

            BlogVM bvm = new BlogVM();
            bvm.Blog = blog;
            bvm.PostDate = blog.PostDate;
            bvm.BlogId = blog.Id;
            bvm.Categories = new List<CategoryVM>();
            List<Category> Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();

            foreach (var category in Categories)
            {
                bvm.Categories.Add(new CategoryVM { Name = category.Name });
            }

            List<CategoryVM> existingCategories = new List<CategoryVM>();
            foreach (var category in blog.BlogCategories)
            {
                CategoryVM categoryVM = new CategoryVM { Name = category.Category.Name };
                existingCategories.Add(categoryVM);
            }

            var filteredListCategories = new List<CategoryVM>();
            foreach (var item in bvm.Categories.ToList())
            {
                if (existingCategories.FirstOrDefault(c => c.Name == item.Name) != null)
                {
                    bvm.Categories.Remove(item);
                }
            }
            filteredListCategories = bvm.Categories;

            ViewBag.Categories = filteredListCategories;

            if (!ModelState.IsValid) return View(bvm);

            var photo = blogVM.Photo;

            if (photo != null)
            {
                if (!FileHelper.CheckContent(photo.ContentType, "image/"))
                {
                    ModelState.AddModelError("Photo", "Please select image format");
                    return View(bvm);
                }

                if (!FileHelper.CheckLength(photo.Length, 200))
                {
                    ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                    return View(bvm);
                }

                FileHelper.DeleteFile(blog.BlogImage.Photo, _env.WebRootPath, "img");
                FileHelper.CreateFile(blogVM.Photo.FileName, _env.WebRootPath, "img", blogVM.Photo);
                blog.BlogImage.Photo = FileHelper.UniqueFileName;
            }

            var existingBlogCategories = await _context.BlogCategories.Select(x => x).Where(c => c.BlogId == blog.Id).ToListAsync();
            foreach (var blogCategory in existingBlogCategories)
            {
                _context.BlogCategories.Remove(blogCategory);
            }

            foreach (var categoryInput in blogVM.CategoriesInput)
            {
                Category category = Categories.Find(c => c.Name == categoryInput);
                BlogCategory blogCategory = new BlogCategory { CategoryId = category.Id, BlogId = blog.Id };
                _context.BlogCategories.Add(blogCategory);
            }

            blog.Name = blogVM.Name;
            blog.AuthorFullName = blogVM.AuthorFullName;
            blog.Content = blogVM.Content;
            blog.PostDate = blogVM.PostDate;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.Where(b => b.IsDeleted == false).FirstOrDefaultAsync(b => b.Id == id);
            if (blog == null) return NotFound();
            blog.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
