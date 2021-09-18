﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Areas.Admin.Helpers;
using EduHome.Areas.Admin.ViewModels;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
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

            return RedirectToAction(nameof(Index));
        }
    }
}
