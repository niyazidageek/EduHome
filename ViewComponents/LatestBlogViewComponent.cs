using System;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.ViewComponents
{
    public class LatestBlogViewComponent:ViewComponent
    {
        public AppDbContext _context { get; }
        public LatestBlogViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Blogs = await _context.Blogs.Where(b => b.IsDeleted == false)
                .OrderByDescending(b => b.Id)
                .Include(b => b.BlogImage)
                .Take(3)
                .ToListAsync();  

            return View(Blogs);
        }
    }
}
