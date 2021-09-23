using System;
using System.Collections.Generic;
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

        public async Task<IActionResult> Index()
        {
            var Events = await _context.Events.Where(e => e.IsDeleted == false)
                .OrderByDescending(e => e.Id)
                .Take(12)
                .Include(e => e.EventImage)
                .ToListAsync();

            EventVM eventVM = new EventVM
            {
                Events = Events
            };

            return View(eventVM);
        }
    }
}
