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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeacherController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult GetSkills(int count)
        {
            //var Skills = _context.Skills.ToList();
            //return Json(Skills);

            return PartialView("_TeacherSkillPartialView",count);
        }

        public async Task<IActionResult> Index()
        {
            List<Teacher> Teachers = await _context.Teachers.Where(t => t.IsDeleted == false)
                .Include(t => t.TeacherImage)
                .Include(t => t.TeacherContact)
                .Include(t => t.TeacherSkills)
                .ThenInclude(t => t.Skill)
                .ToListAsync();

            return View(Teachers);
        }

        public IActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher(TeacherVM teacherVM)
        {
            if (!ModelState.IsValid) return View(teacherVM);

            var photo = teacherVM.Photo;
            if (photo == null)
            {
                ModelState.AddModelError("Photo", "Photo can not be empty");
                return View(teacherVM);
            }

            if (!FileHelper.CheckContent(photo.ContentType, "image/"))
            {
                ModelState.AddModelError("Photo", "Please select image format");
                return View(teacherVM);
            }

            if (!FileHelper.CheckLength(photo.Length, 200))
            {
                ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                return View(teacherVM);
            }

            FileHelper.CreateFile(photo.FileName, _env.WebRootPath, "img", photo);

            Teacher teacher = new Teacher
            {
                FullName = teacherVM.Fullname,
                Position = teacherVM.Position,
                Info = teacherVM.Info,
                Degree = teacherVM.Degree,
                Experience = teacherVM.Experience,
                Hobbies = teacherVM.Hobbies,
                Faculty = teacherVM.Faculty,
                TeacherImage = new TeacherImage { Photo = FileHelper.UniqueFileName},
                TeacherContact = new TeacherContact
                {
                    Mail = teacherVM.Mail,
                    Phone = teacherVM.Phone,
                    FacebookUserName = teacherVM.FacebookUserName,
                    PinterestUserName = teacherVM.PinterestUserName,
                    TwitterUserName = teacherVM.TwitterUserName,
                    SkypeUserName = teacherVM.SkypeUserName
                }
            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();


            

            return Content("ok");
        }
    }
}
