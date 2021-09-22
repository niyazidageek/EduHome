using System;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.ViewComponents
{
    public class NewstellerViewComponent : ViewComponent
    {
        public AppDbContext _context { get; }
        public NewstellerViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(Subscriber subscriber)
        {
            return View(subscriber);
        }
    }
}
