using System;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        public AppDbContext _context { get; }
        public BlogViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var Blogs = await _context.Blogs.Where(b => b.IsDeleted == false)
                .Take(count)
                .Include(b => b.BlogImage)
                .Include(b=>b.Comments)
                .ToListAsync();

            return View(Blogs);
        }
    }
}
