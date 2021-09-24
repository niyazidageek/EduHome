using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BlogCommentController : Controller
    {
        private readonly AppDbContext _context;

        public BlogCommentController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()

        {
            var blogs = await _context.Blogs.Where(e => e.IsDeleted == false)
                .Include(b => b.BlogImage)
                .Include(b => b.Comments)
                .ToListAsync();

            return View(blogs);
        }

        public IActionResult ViewComment(int id)
        {
            var blog = _context.Blogs.Where(b => b.IsDeleted == false)
                .Include(b => b.Comments.Where(c=>c.IsDeleted==false))
                .FirstOrDefault(b => b.Id == id);

            return View(blog);
        }

        public IActionResult DetailComment(int id)
        {
            var comment = _context.Comments.Where(c => c.IsDeleted == false)
                .Include(b=>b.Blog)
                .FirstOrDefault(c => c.Id == id);

            return View(comment);
        }

        public IActionResult DeleteComment(int id)
        {
            var comment = _context.Comments.Include(c=>c.Blog).FirstOrDefault(c=>c.Id == id);
            int blogId = comment.Blog.Id;

            if (comment == null) return NotFound();

            comment.IsDeleted = true;
            _context.SaveChanges();

            return RedirectToAction(nameof(ViewComment),new { id = blogId });
        }
    }
}
