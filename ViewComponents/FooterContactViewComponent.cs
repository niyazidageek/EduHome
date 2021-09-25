using System;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.ViewComponents
{
    public class FooterContactViewComponent: ViewComponent
    {
        public AppDbContext _context { get; }
        public FooterContactViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contact = _context.Contact.ToList().ElementAt(0);

            return View(contact);
        }
    }
}
