using System;
using System.Threading.Tasks;
using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.ViewComponents
{
    public class WelcomeSectionViewComponent:ViewComponent
    {
        public AppDbContext _context { get; }
        public WelcomeSectionViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
