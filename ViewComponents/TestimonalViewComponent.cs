using System;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.ViewComponents
{
    public class TestimonalViewComponent:ViewComponent
    {
        public AppDbContext _context { get; }

        public TestimonalViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonal = _context.Testimonal.ToList().ElementAt(0);

            return View(testimonal);
        }
    }
}
