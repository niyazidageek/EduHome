using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
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
                .Include(b => b.Comments)
                .ToList()
                .ToPagedList(number ?? 1, 12);

            BlogVM blogVM = new BlogVM
            {
                Blogs = Blogs
            };

            return View(blogVM);
        }
    }
}
