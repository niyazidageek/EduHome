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
using EduHome.Models;

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

        public IActionResult EventDetail(int id)
        {
            var _event = _context.Events.Where(e => e.IsDeleted == false)
                .Include(e => e.EventImage)
                .Include(e => e.EventCategories)
                .ThenInclude(e => e.Category)
                .Include(s=>s.SpeakerEvents)
                .ThenInclude(s=>s.Speaker)
                .ThenInclude(s=>s.SpeakerImage)
                .FirstOrDefault(e => e.Id == id);

            if (_event == null) return NotFound();

            List<string> Categories = new List<string>();
            List<Speaker> Speakers = new List<Speaker>();

            foreach (var speakerEvent in _event.SpeakerEvents)
            {
                Speakers.Add(speakerEvent.Speaker);
            }

            foreach (var eventCategory in _event.EventCategories)
            {
                Categories.Add(eventCategory.Category.Name);
            }

            EventDetailVM eventDetailVM = new EventDetailVM
            {
                Name = _event.Name,
                StartTime = _event.StartTime,
                EndTime = _event.EndTime,
                Venue = _event.Venue,
                Description = _event.Description,
                Photo = _event.EventImage.Photo,
                Categories = Categories,
                Speakers = Speakers
            };

            return View(eventDetailVM); 
        }
    }
}
