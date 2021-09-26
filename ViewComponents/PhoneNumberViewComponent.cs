using System;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.ViewComponents
{
    public class PhoneNumberViewComponent:ViewComponent
    {
        public AppDbContext _context { get; }

        public PhoneNumberViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Contact = _context.Contact
                .ToList();

            var contact = Contact.ElementAt(0);

            return View(contact);
        }
    }
}
