using System;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.ViewComponents
{
    public class TeacherViewComponent:ViewComponent
    {
        public AppDbContext _context { get; }
        public TeacherViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var Teachers = await _context.Teachers.Where(t => t.IsDeleted == false)
                .Take(count)
                .OrderByDescending(t=>t.Id)
                .Include(t => t.TeacherImage)
                .Include(t => t.TeacherContact)
                .ToListAsync();

            return View(Teachers);
        }
    }
}
