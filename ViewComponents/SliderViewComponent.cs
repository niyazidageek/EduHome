using System;
using System.Threading.Tasks;
using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.ViewComponents
{
    public class SliderViewComponent:ViewComponent
    {
        public AppDbContext _context { get; }
        public SliderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Sliders = await _context.Sliders.ToListAsync();
            return View(Sliders);
        }
    }
}
