using System;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.ViewComponents
{
    public class NoticeBoardViewComponent:ViewComponent
    {
        public AppDbContext _context { get; }
        public NoticeBoardViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Messages = await _context.NoticeBoardItems.Where(n => n.IsDeleted == false)
                .ToListAsync();

            return View(Messages);
        }
    }
}
