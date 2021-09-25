using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EduHome.Areas.Admin.Helpers;
using EduHome.Areas.Admin.ViewModels;
using EduHome.DAL;
using EduHome.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace EduHome.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;

        public EventController(UserManager<AppUser> userManager,AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Event> Events = await _context.Events.Where(e=>e.IsDeleted==false)
                .Include(e => e.SpeakerEvents)
                .ThenInclude(e => e.Speaker)
                .Include(e => e.EventCategories)
                .ThenInclude(e=>e.Category)
                .Include(e=>e.EventImage)
                .ToListAsync();

            return View(Events);
        }

        public async Task<IActionResult> CreateEvent()
        {
            EventVM ev = new EventVM();
            ev.Categories = new List<CategoryVM>();
            ev.Speakers = new List<SpeakerVM>();
            List<Category> Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            List<Speaker> Speakers = await _context.Speakers.Where(c => c.IsDeleted == false).ToListAsync();

            foreach (var category in Categories)
            {
                ev.Categories.Add(new CategoryVM { Name = category.Name });
            }

            foreach (var speaker in Speakers)
            {
                ev.Speakers.Add(new SpeakerVM { Name = speaker.Name });
            }

            return View(ev);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventVM eventVM)
        {
            EventVM ev = new EventVM();
            ev.Categories = new List<CategoryVM>();
            ev.Speakers = new List<SpeakerVM>();
            List<Category> Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            List<Speaker> Speakers = await _context.Speakers.Where(c => c.IsDeleted == false).ToListAsync();

            foreach (var category in Categories)
            {
                ev.Categories.Add(new CategoryVM { Name = category.Name });
            }

            foreach (var speaker in Speakers)
            {
                ev.Speakers.Add(new SpeakerVM { Name = speaker.Name });
            }

            if (!ModelState.IsValid) return View(ev);

            var photo = eventVM.Photo;

            if (photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be empty");
                return View(ev);
            }

            if (!FileHelper.CheckContent(photo.ContentType, "image/"))
            {
                ModelState.AddModelError("Photo", "Please select image format");
                return View(ev);
            }

            if (!FileHelper.CheckLength(photo.Length, 200))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                return View(ev);
            }

            FileHelper.CreateFile(photo.FileName, _env.WebRootPath, "img", photo);

            Event _event = new Event
            {
                Name = eventVM.Name,
                Description = eventVM.Description,
                Venue = eventVM.Venue,
                StartTime = eventVM.StartTime,
                EndTime = eventVM.EndTime,
                IsDeleted = false,
                EventImage = new EventImage { Photo = FileHelper.UniqueFileName }
            };

            _context.Events.Add(_event);
            _context.SaveChanges();

            foreach (var categoryInput in eventVM.CategoriesInput)
            {
                Category category = Categories.Find(c => c.Name == categoryInput);
                EventCategory eventCategory = new EventCategory { CategoryId = category.Id, EventId = _event.Id };
                _context.EventCategories.Add(eventCategory);
                _context.SaveChanges();
            }

            foreach (var speakerInput in eventVM.SpeakersInput)
            {
                Speaker speaker = Speakers.Find(s => s.Name == speakerInput);
                SpeakerEvent speakerEvent = new SpeakerEvent { EventId = _event.Id, SpeakerId = speaker.Id };
                _context.SpeakerEvents.Add(speakerEvent);
                _context.SaveChanges();
            }

            List<string> Receivers = new List<string>();
            var users = await _userManager.GetUsersInRoleAsync(Roles.Client.ToString());
            var subscribers = await _context.Subscribers.ToListAsync();

            foreach (var user in users)
            {
                Receivers.Add(user.Email);
            }
            
            foreach (var subscriber in subscribers)
            {
                Receivers.Add(subscriber.Email);
            }

            Receivers = Receivers.Distinct().ToList();

            EmailHelper.SendEmail(Receivers, "New event!", $"{_event.Name} is available now");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditEvent(int id)
        {
            var _event = await _context.Events.Where(e => e.IsDeleted == false)
                .Include(e => e.EventImage)
                .Include(e => e.EventCategories)
                .ThenInclude(e => e.Category)
                .Include(e => e.SpeakerEvents)
                .ThenInclude(e => e.Speaker)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (_event == null) return NotFound();

            EventVM ev = new EventVM();
            ev.Categories = new List<CategoryVM>();
            ev.Speakers = new List<SpeakerVM>();
            ev.Event = _event;
            ev.StartTime = _event.StartTime;
            ev.EndTime = _event.EndTime;
            List<Category> Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            List<Speaker> Speakers = await _context.Speakers.Where(c => c.IsDeleted == false).ToListAsync();

            foreach (var category in Categories)
            {
                ev.Categories.Add(new CategoryVM { Name = category.Name });
            }

            foreach (var speaker in Speakers)
            {
                ev.Speakers.Add(new SpeakerVM { Name = speaker.Name });
            }

            
            
            List<CategoryVM> existingCategories = new List<CategoryVM>();
            foreach (var category in _event.EventCategories)
            {
                CategoryVM categoryVM = new CategoryVM { Name = category.Category.Name };
                existingCategories.Add(categoryVM);
            }

            var filteredListCategories = new List<CategoryVM>();
            foreach (var item in ev.Categories.ToList())
            {
                if (existingCategories.FirstOrDefault(c => c.Name == item.Name) != null)
                {
                    ev.Categories.Remove(item);
                }
            }
            filteredListCategories = ev.Categories;

            ViewBag.Categories = filteredListCategories;



            List<SpeakerVM> existingSpeakers = new List<SpeakerVM>();
            foreach (var speaker in _event.SpeakerEvents)
            {
                SpeakerVM speakerVM = new SpeakerVM { Name = speaker.Speaker.Name };
                existingSpeakers.Add(speakerVM);
            }

            var filteredListSpeakers = new List<SpeakerVM>();
            foreach (var item in ev.Speakers.ToList())
            {
                if (existingSpeakers.FirstOrDefault(s => s.Name == item.Name) != null)
                {
                    ev.Speakers.Remove(item);
                }
            }
            filteredListSpeakers= ev.Speakers;

            ViewBag.Speakers = filteredListSpeakers;

            return View(ev);
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(EventVM eventVM)
        {
            var _event = await _context.Events.Where(e => e.IsDeleted == false)
                .Include(e => e.EventImage)
                .Include(e => e.EventCategories)
                .ThenInclude(e => e.Category)
                .Include(e => e.SpeakerEvents)
                .ThenInclude(e => e.Speaker)
                .FirstOrDefaultAsync(e => e.Id == eventVM.EventId);

            if (_event == null) return NotFound();

            EventVM ev = new EventVM();
            ev.Categories = new List<CategoryVM>();
            ev.Speakers = new List<SpeakerVM>();
            ev.Event = _event;
            ev.StartTime = _event.StartTime;
            ev.EndTime = _event.EndTime;
            List<Category> Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            List<Speaker> Speakers = await _context.Speakers.Where(c => c.IsDeleted == false).ToListAsync();

            foreach (var category in Categories)
            {
                ev.Categories.Add(new CategoryVM { Name = category.Name });
            }

            foreach (var speaker in Speakers)
            {
                ev.Speakers.Add(new SpeakerVM { Name = speaker.Name });
            }



            List<CategoryVM> existingCategories = new List<CategoryVM>();
            foreach (var category in _event.EventCategories)
            {
                CategoryVM categoryVM = new CategoryVM { Name = category.Category.Name };
                existingCategories.Add(categoryVM);
            }

            var filteredListCategories = new List<CategoryVM>();
            foreach (var item in ev.Categories.ToList())
            {
                if (existingCategories.FirstOrDefault(c => c.Name == item.Name) != null)
                {
                    ev.Categories.Remove(item);
                }
            }
            filteredListCategories = ev.Categories;

            ViewBag.Categories = filteredListCategories;



            List<SpeakerVM> existingSpeakers = new List<SpeakerVM>();
            foreach (var speaker in _event.SpeakerEvents)
            {
                SpeakerVM speakerVM = new SpeakerVM { Name = speaker.Speaker.Name };
                existingSpeakers.Add(speakerVM);
            }

            var filteredListSpeakers = new List<SpeakerVM>();
            foreach (var item in ev.Speakers.ToList())
            {
                if (existingSpeakers.FirstOrDefault(s => s.Name == item.Name) != null)
                {
                    ev.Speakers.Remove(item);
                }
            }
            filteredListSpeakers = ev.Speakers;

            ViewBag.Speakers = filteredListSpeakers;



            if (!ModelState.IsValid) return View(ev);


            var photo = eventVM.Photo;

            if (photo!= null)
            {
                if (!FileHelper.CheckContent(photo.ContentType, "image/"))
                {
                    ModelState.AddModelError("Photo", "Please select image format");
                    return View(ev);
                }

                if (!FileHelper.CheckLength(photo.Length, 200))
                {
                    ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                    return View(ev);
                }

                FileHelper.DeleteFile(_event.EventImage.Photo, _env.WebRootPath, "img");
                FileHelper.CreateFile(eventVM.Photo.FileName, _env.WebRootPath, "img", eventVM.Photo);
                _event.EventImage.Photo = FileHelper.UniqueFileName;
            }

            var existingEventCategories = await _context.EventCategories.Select(x => x).Where(c => c.EventId == _event.Id).ToListAsync();
            foreach (var eventcategory in existingEventCategories)
            {
                _context.EventCategories.Remove(eventcategory);
            }

            foreach (var categoryInput in eventVM.CategoriesInput)
            {
                Category category = Categories.Find(c => c.Name == categoryInput);
                EventCategory eventCategory = new EventCategory { CategoryId = category.Id, EventId = _event.Id };
                _context.EventCategories.Add(eventCategory);
            }

            var existingSpeakerEvents = await _context.SpeakerEvents.Select(x => x).Where(c => c.EventId == _event.Id).ToListAsync();
            foreach (var speakerevent in existingSpeakerEvents)
            {
                _context.SpeakerEvents.Remove(speakerevent);
            }

            foreach (var speakerInput in eventVM.SpeakersInput)
            {
                Speaker speaker = Speakers.Find(s => s.Name == speakerInput);
                SpeakerEvent speakerEvent = new SpeakerEvent { SpeakerId = speaker.Id, EventId = _event.Id };
                _context.SpeakerEvents.Add(speakerEvent);
            }


            _event.Name = eventVM.Name;
            _event.Description = eventVM.Description;
            _event.Venue = eventVM.Venue;
            _event.StartTime = eventVM.StartTime;
            _event.EndTime = eventVM.EndTime;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewEvent(int id)
        {
            var _event = _context.Events.Where(e => e.IsDeleted == false)
                .Include(e => e.EventImage)
                .Include(e => e.EventCategories)
                .ThenInclude(e => e.Category)
                .Include(e => e.SpeakerEvents)
                .ThenInclude(e => e.Speaker)
                .ThenInclude(e=>e.SpeakerImage)
                .FirstOrDefault(e => e.Id == id);

            return View(_event);
        }
    }
}
