using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Areas.Admin.Helpers;
using EduHome.Areas.Admin.ViewModels;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SpeakerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SpeakerController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Speaker> Speakers = await _context.Speakers.Where(s=>s.IsDeleted == false).Include(s => s.SpeakerImage).ToListAsync();
            return View(Speakers);
        }

        public IActionResult CreateSpeaker()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSpeaker(SpeakerVM speakerVM)
        {
            if (!ModelState.IsValid) return View(speakerVM);

            var photo = speakerVM.Photo;

            if (photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be empty");
                return View(speakerVM);
            }

            if (!FileHelper.CheckContent(photo.ContentType, "image/"))
            {
                ModelState.AddModelError("Photo", "Please select image format");
                return View(speakerVM);
            }

            if (!FileHelper.CheckLength(photo.Length, 200))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                return View(speakerVM);
            }

            FileHelper.CreateFile(photo.FileName, _env.WebRootPath, "img", photo);          

            var speaker = new Speaker
            {
                Name = speakerVM.Name,
                Position = speakerVM.Position,
                SpeakerImage = new SpeakerImage { Photo = FileHelper.UniqueFileName}
            };

            _context.Speakers.Add(speaker);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteSpeaker(int id)
        {
            var speaker = await _context.Speakers.Where(s=>s.IsDeleted==false).FirstOrDefaultAsync(s => s.Id == id);
            if (speaker == null) return NotFound();
            speaker.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditSpeaker(int id)
        {
            var speaker = await _context.Speakers.Where(s => s.IsDeleted == false).Include(s=>s.SpeakerImage).FirstOrDefaultAsync(s => s.Id == id);
            if (speaker == null) return NotFound();
            SpeakerVM speakerVM = new SpeakerVM
            {
                Name = speaker.Name,
                Position = speaker.Position,
                Image = speaker.SpeakerImage.Photo,
                SpeakerId = speaker.Id
            };
            return View(speakerVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditSpeaker(SpeakerVM speakerVM)
        {
            if (!ModelState.IsValid) return View(speakerVM);
            var speaker = await _context.Speakers.Where(s => s.IsDeleted == false).Include(s => s.SpeakerImage).FirstOrDefaultAsync(s => s.Id == speakerVM.SpeakerId);
            if (speaker == null) return NotFound();

            var photo = speakerVM.Photo;

            if (photo != null)
            {
                if (!FileHelper.CheckContent(photo.ContentType, "image/"))
                {
                    ModelState.AddModelError("Photo", "Please select image format");
                    return View(speakerVM);
                }

                if (!FileHelper.CheckLength(photo.Length, 200))
                {
                    ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                    return View(speakerVM);
                }

                FileHelper.DeleteFile(speaker.SpeakerImage.Photo, _env.WebRootPath, "img");
                FileHelper.CreateFile(speakerVM.Photo.FileName, _env.WebRootPath, "img", speakerVM.Photo);
                speaker.SpeakerImage.Photo = FileHelper.UniqueFileName;

            }
            speaker.Name = speakerVM.Name;
            speaker.Position = speakerVM.Position;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
