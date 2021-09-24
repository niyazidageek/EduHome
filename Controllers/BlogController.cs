using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace EduHome.ViewComponents
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? number)
        {
            var Blogs = _context.Blogs.Where(e => e.IsDeleted == false)
                .Include(b => b.BlogImage)
                .Include(b => b.Comments.Where(c=>c.IsDeleted == false))
                .ToList()
                .ToPagedList(number ?? 1, 12);

            BlogVM blogVM = new BlogVM
            {
                Blogs = Blogs
            };

            return View(blogVM);
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            var Blogs = await _context.Blogs.Where(e => e.IsDeleted == false)
                .Take(3)
                .Include(b => b.BlogImage)
                .Include(b => b.Comments.Where(c => c.IsDeleted == false))
                .Include(b=>b.BlogCategories)
                .ThenInclude(b=>b.Category)
                .ToListAsync();

            var blog = await _context.Blogs.Where(b => b.IsDeleted == false)
                .Include(b => b.BlogImage)
                .Include(b => b.Comments.Where(c => c.IsDeleted == false))
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blog == null) return NotFound();

            BlogDetailVM blogDetailVM = new BlogDetailVM
            {
                Blog = blog,
                Blogs = Blogs
            };

            return View(blogDetailVM);
        }

        [HttpPost]
        public async Task<IActionResult> BlogDetail(BlogDetailVM blogDetailVM, int blogId)
        {
            var Blogs = await _context.Blogs.Where(e => e.IsDeleted == false)
                .Take(3)
                .Include(b => b.BlogImage)
                .Include(b => b.Comments.Where(c => c.IsDeleted == false))
                .Include(b => b.BlogCategories)
                .ThenInclude(b => b.Category)
                .ToListAsync();

            var blog = await _context.Blogs.Where(b => b.IsDeleted == false)
                .Include(b => b.BlogImage)
                .Include(b => b.Comments.Where(c => c.IsDeleted == false))
                .FirstOrDefaultAsync(b => b.Id == blogId);

            if (blog == null) return NotFound();

            BlogDetailVM bvm = new BlogDetailVM
            {
                Blog = blog,
                Blogs = Blogs
            };


            if (!ModelState.IsValid) return View(bvm);

            Comment comment = new Comment
            {
                FullName = blogDetailVM.Comment.FullName,
                Mail = blogDetailVM.Comment.Mail,
                Subject = blogDetailVM.Comment.Subject,
                Message = blogDetailVM.Comment.Message,
                Blog = blog,
                IsDeleted = false
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction(nameof(BlogDetail), new { id = blogId });
        }
    }
}
