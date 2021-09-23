using System;
using System.Collections.Generic;
using X.PagedList.Mvc.Core;
using X.PagedList;
using X.PagedList.Mvc;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? number)
        {
            var Events = _context.Events.Where(e => e.IsDeleted == false)
                .OrderByDescending(e => e.Id)
                .Include(e => e.EventImage)
                .ToList()
                .ToPagedList(number ?? 1, 12);

            EventVM eventVM = new EventVM
            {
                Events = Events
            };

            return View(eventVM);
        }
    }
}
