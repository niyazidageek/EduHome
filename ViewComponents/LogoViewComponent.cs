using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.ViewComponents
{
    public class LogoViewComponent:ViewComponent
    {
        public AppDbContext _context { get; }

        public LogoViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Logo = _context.Logo
                .ToList();

            var logo = Logo.ElementAt(0);

            return View(logo);
        }
    }
}
