using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Areas.Admin.Helpers;
using EduHome.Areas.Admin.ViewModels;
using EduHome.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace EduHome.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class LogoController : Controller
    {
        public AppDbContext _context { get; }
        private readonly IWebHostEnvironment _env;

        public LogoController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var logo = _context.Logo.ToList();
            return View(logo.ElementAt(0));
        }

        public IActionResult EditLogo()
        {
            var logo = _context.Logo.ToList();
            LogoVM logoVM = new LogoVM()
            {
                Image = logo.ElementAt(0).Photo
            };
            return View(logoVM);
        }

        [HttpPost]
        public IActionResult EditLogo(LogoVM logoVM)
        {
            var logo = _context.Logo.ToList();

            LogoVM lvm = new LogoVM()
            {
                Image = logo.ElementAt(0).Photo
            };

            if (!ModelState.IsValid) return View(lvm);

            var photo = logoVM.Photo;

            if (!FileHelper.CheckContent(photo.ContentType, "image/"))
            {
                ModelState.AddModelError("Photo", "Please select image format");
                return View(lvm);
            }

            if (!FileHelper.CheckLength(photo.Length, 200))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                return View(lvm);
            }

            FileHelper.DeleteFile(logo.ElementAt(0).Photo, _env.WebRootPath, "img");
            FileHelper.CreateFile(photo.FileName, _env.WebRootPath, "img", photo);
            logo.ElementAt(0).Photo = FileHelper.UniqueFileName;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
