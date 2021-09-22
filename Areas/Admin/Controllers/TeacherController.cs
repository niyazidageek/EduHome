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
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeacherController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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

        public async Task<IActionResult> CreateTeacher()
        {
            TeacherVM teacherVM = new TeacherVM();
            teacherVM.Skills = new List<SkillVM>();
            List<Skill> Skills = await _context.Skills.Where(s => s.IsDeleted == false).ToListAsync();
            foreach (var skill in Skills)
            {
                teacherVM.Skills.Add(new SkillVM { Name = skill.Name });
            }
            return View(teacherVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher(TeacherVM teacherVM)
        {

            TeacherVM tvm = new TeacherVM();
            tvm.Skills = new List<SkillVM>();
            List<Skill> Skills = await _context.Skills.Where(s => s.IsDeleted == false).ToListAsync();
            foreach (var skill in Skills)
            {
                tvm.Skills.Add(new SkillVM { Name = skill.Name });
            }

            if (!ModelState.IsValid) return View(tvm);

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
                IsDeleted = true,
                TeacherImage = new TeacherImage { Photo = FileHelper.UniqueFileName },
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

            string[] incomingPercents = teacherVM.PercentagesInput.Split(',');

            for (int i = 0; i < teacherVM.SkillsInput.Count; i++)
            {
                var skillIncoming = teacherVM.SkillsInput.ElementAt(i);
                Skill skill = Skills.Find(c => c.Name == skillIncoming);
                var percentIncoming = incomingPercents[i];
                TeacherSkill teacherSkill = new TeacherSkill { SkillId = skill.Id, TeacherId = teacher.Id, Percentage = percentIncoming };
                _context.TeacherSkills.Add(teacherSkill);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditTeacher(int id)
        {      
            var teacher = await _context.Teachers.Where(t => t.IsDeleted == false)
                .Include(t => t.TeacherImage)
                .Include(t => t.TeacherContact)
                .Include(t => t.TeacherSkills)
                .ThenInclude(t => t.Skill)
                .FirstOrDefaultAsync(t=>t.Id == id);

            if (teacher == null) return NotFound();

            TeacherVM tvm = new TeacherVM();
            tvm.Skills = new List<SkillVM>();
            tvm.Teacher = teacher;
            tvm.TeacherId = teacher.Id;
            List<string> Percentages = new List<string>();
            List<Skill> Skills = await _context.Skills.Where(s => s.IsDeleted == false).ToListAsync();
            foreach (var skill in Skills)
            {
                tvm.Skills.Add(new SkillVM { Name = skill.Name });
            }
            foreach (var teacherSkill in teacher.TeacherSkills)
            {
                Percentages.Add(teacherSkill.Percentage);
            }
            tvm.PercentagesInput = string.Join(",", Percentages);



            List<SkillVM> existingSkills = new List<SkillVM>();
            foreach (var skill in teacher.TeacherSkills)
            {
                SkillVM skillVM = new SkillVM { Name = skill.Skill.Name };
                existingSkills.Add(skillVM);
            }

            var filteredListSkills = new List<SkillVM>();
            foreach (var item in tvm.Skills.ToList())
            {
                if (existingSkills.FirstOrDefault(c => c.Name == item.Name) != null)
                {
                    tvm.Skills.Remove(item);
                }
            }
            filteredListSkills = tvm.Skills;

            ViewBag.Skills = filteredListSkills;

            return View(tvm);
        }

        [HttpPost]
        public async Task<IActionResult> EditTeacher(TeacherVM teacherVM)
        {
            var teacher = await _context.Teachers.Where(t => t.IsDeleted == false)
                .Include(t => t.TeacherImage)
                .Include(t => t.TeacherContact)
                .Include(t => t.TeacherSkills)
                .ThenInclude(t => t.Skill)
                .FirstOrDefaultAsync(t => t.Id == teacherVM.TeacherId);

            TeacherVM tvm = new TeacherVM();
            tvm.Skills = new List<SkillVM>();
            tvm.Teacher = teacher;
            tvm.TeacherId = teacher.Id;
            List<string> Percentages = new List<string>();
            List<Skill> Skills = await _context.Skills.Where(s => s.IsDeleted == false).ToListAsync();
            foreach (var skill in Skills)
            {
                tvm.Skills.Add(new SkillVM { Name = skill.Name });
            }
            foreach (var teacherSkill in teacher.TeacherSkills)
            {
                Percentages.Add(teacherSkill.Percentage);
            }
            tvm.PercentagesInput = string.Join(",", Percentages);



            List<SkillVM> existingSkills = new List<SkillVM>();
            foreach (var skill in teacher.TeacherSkills)
            {
                SkillVM skillVM = new SkillVM { Name = skill.Skill.Name };
                existingSkills.Add(skillVM);
            }

            var filteredListSkills = new List<SkillVM>();
            foreach (var item in tvm.Skills.ToList())
            {
                if (existingSkills.FirstOrDefault(c => c.Name == item.Name) != null)
                {
                    tvm.Skills.Remove(item);
                }
            }
            filteredListSkills = tvm.Skills;

            ViewBag.Skills = filteredListSkills;

            if (teacher == null) return NotFound();

            if (!ModelState.IsValid) return View(tvm);



            var existingImage = await _context.TeacherImage.FirstOrDefaultAsync(ci => ci.TeacherId == teacher.Id);
            if (existingImage == null) return NotFound();

            var photo = teacherVM.Photo;

            if (photo != null)
            {
                if (!FileHelper.CheckContent(photo.ContentType, "image/"))
                {
                    ModelState.AddModelError("Photo", "Please select image format");
                    return View(tvm);
                }

                if (!FileHelper.CheckLength(photo.Length, 200))
                {
                    ModelState.AddModelError("Photo", "Image size must be less than 200kb");
                    return View(tvm);
                }

                FileHelper.DeleteFile(existingImage.Photo, _env.WebRootPath, "img");
                FileHelper.CreateFile(teacherVM.Photo.FileName, _env.WebRootPath, "img", teacherVM.Photo);
                teacher.TeacherImage.Photo = FileHelper.UniqueFileName;
            }

            var existingTeacherSkils = await _context.TeacherSkills.Select(x => x).Where(c => c.TeacherId == teacher.Id).ToListAsync();
            foreach (var teacherSkill in existingTeacherSkils)
            {
                _context.TeacherSkills.Remove(teacherSkill);
            }

            string[] incomingPercents = teacherVM.PercentagesInput.Split(',');

            for (int i = 0; i < teacherVM.SkillsInput.Count; i++)
            {
                var skillIncoming = teacherVM.SkillsInput.ElementAt(i);
                Skill skill = Skills.Find(c => c.Name == skillIncoming);
                var percentIncoming = incomingPercents[i];
                TeacherSkill teacherSkill = new TeacherSkill { SkillId = skill.Id, TeacherId = teacher.Id, Percentage = percentIncoming };
                _context.TeacherSkills.Add(teacherSkill);
                _context.SaveChanges();
            }

            teacher.FullName = teacherVM.Fullname;
            teacher.Faculty = teacherVM.Faculty;
            teacher.Degree = teacherVM.Degree;
            teacher.Experience = teacherVM.Experience;
            teacher.Info = teacherVM.Info;
            teacher.Position = teacherVM.Position;
            teacher.TeacherContact.Mail = teacherVM.Mail;
            teacher.TeacherContact.SkypeUserName = teacherVM.SkypeUserName;
            teacher.TeacherContact.TwitterUserName = teacherVM.TwitterUserName;
            teacher.TeacherContact.Phone = teacherVM.Phone;
            teacher.Hobbies = teacherVM.Hobbies;
            teacher.TeacherContact.FacebookUserName = teacherVM.FacebookUserName;
            teacher.TeacherContact.PinterestUserName = teacherVM.PinterestUserName;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.Where(t => t.IsDeleted == false).FirstOrDefaultAsync(t => t.Id == id);
            if (teacher == null) return NotFound();
            teacher.IsDeleted = true;
            _context.SaveChanges(); 
            return RedirectToAction(nameof(Index));
        }
    }
}
