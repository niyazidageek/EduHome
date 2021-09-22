using System;
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
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> Sliders = await _context.Sliders.ToListAsync();
            return View(Sliders);
        }

        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSlider(SliderVM sliderVM)
        {
            if (!ModelState.IsValid) return View(sliderVM);

            var photo = sliderVM.Photo;

            if (photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be empty");
                return View(sliderVM);
            }

            if (!FileHelper.CheckContent(photo.ContentType, "image/"))
            {
                ModelState.AddModelError("Photo", "Please select image format");
                return View(sliderVM);
            }

            if (!FileHelper.CheckLength(photo.Length, 200))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                return View(sliderVM);
            }

            FileHelper.CreateFile(photo.FileName, _env.WebRootPath, "img", photo);

            Slider slider = new Slider
            {
                Text = sliderVM.Text,
                Title = sliderVM.Title,
                ButtonText = sliderVM.ButtonText,
                Photo = FileHelper.UniqueFileName
            };

            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditSlider(int id)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return NotFound();
            SliderVM sliderVM = new SliderVM
            {
                Slider = slider,
                SliderId = slider.Id
            };

            return View(sliderVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditSlider(SliderVM sliderVM)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == sliderVM.SliderId);
            if (slider == null) return NotFound();
            if (!ModelState.IsValid) return View(sliderVM);

            var photo = sliderVM.Photo;

            if(photo != null)
            {
                if (!FileHelper.CheckContent(photo.ContentType, "image/"))
                {
                    ModelState.AddModelError("Photo", "Please select image format");
                    return View(sliderVM);
                }

                if (!FileHelper.CheckLength(photo.Length, 200))
                {
                    ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                    return View(sliderVM);
                }

                FileHelper.DeleteFile(slider.Photo, _env.WebRootPath, "img");
                FileHelper.CreateFile(sliderVM.Photo.FileName, _env.WebRootPath, "img", sliderVM.Photo);
                slider.Photo = FileHelper.UniqueFileName;
            }

            slider.Text = sliderVM.Text;
            slider.Title = sliderVM.Title;
            slider.ButtonText = sliderVM.ButtonText;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteSlider(int id)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return NotFound();
            _context.Sliders.Remove(slider);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
