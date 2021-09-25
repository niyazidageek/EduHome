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
    public class TestimonalController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TestimonalController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var testimonal = _context.Testimonal.ToList().ElementAt(0);
            return View(testimonal);
        }

        public IActionResult EditTestimonal()
        {
            var testimonal = _context.Testimonal.ToList().ElementAt(0);
            TestimonalVM testimonalVM = new TestimonalVM
            {
                Fullname = testimonal.Fullname,
                Position = testimonal.Position,
                Text = testimonal.Text,
                Image = testimonal.PersonPhoto
            };

            return View(testimonalVM);
        }

        [HttpPost]
        public IActionResult EditTestimonal(TestimonalVM testimonalVM)
        {
            if (!ModelState.IsValid) return View(testimonalVM);

            var testimonal = _context.Testimonal.ToList().ElementAt(0);

            var photo = testimonalVM.Photo;

            if (photo != null)
            {
                if (!FileHelper.CheckContent(photo.ContentType, "image/"))
                {
                    ModelState.AddModelError("Photo", "Please select image format");
                    return View(testimonalVM);
                }

                if (!FileHelper.CheckLength(photo.Length, 200))
                {
                    ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                    return View(testimonalVM);
                }

                FileHelper.DeleteFile(testimonal.PersonPhoto, _env.WebRootPath, "img");
                FileHelper.CreateFile(testimonalVM.Photo.FileName, _env.WebRootPath, "img", testimonalVM.Photo);
                testimonal.PersonPhoto = FileHelper.UniqueFileName;
            }

            testimonal.Fullname = testimonalVM.Fullname;
            testimonal.Position = testimonalVM.Position;
            testimonal.Text = testimonalVM.Text;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewTestimonal()
        {
            var testimonal = _context.Testimonal.ToList().ElementAt(0);

            return View(testimonal);
        }
    }
}
