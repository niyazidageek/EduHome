using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EduHome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TeacherDetail(int id)
        {
            var teacher = await _context.Teachers.AsQueryable().Where(t => t.IsDeleted == false)
                .Include(t => t.TeacherImage)
                .Include(t => t.TeacherContact)
                .Include(t => t.TeacherSkills)
                .ThenInclude(t => t.Skill)
                .FirstOrDefaultAsync(t => t.Id == id);

            List<string> Skills = new List<string>();
            List<string> Percents = new List<string>();
            

            foreach (var teacherSkill in teacher.TeacherSkills)
            {
                Skills.Add(teacherSkill.Skill.Name);
                Percents.Add(teacherSkill.Percentage);
            }

            TeacherDetailVM teacherDetailVM = new TeacherDetailVM
            {
                FullName = teacher.FullName,
                Position = teacher.Position,
                Info = teacher.Info,
                Degree = teacher.Degree,
                Experience = teacher.Experience,
                Hobbies = teacher.Hobbies,
                Faculty = teacher.Faculty,
                Photo = teacher.TeacherImage.Photo,
                Mail = teacher.TeacherContact.Mail,
                Phone = teacher.TeacherContact.Phone,
                SkypeUserName = teacher.TeacherContact.SkypeUserName,
                FacebookUserName = teacher.TeacherContact.FacebookUserName,
                PinterestUserName = teacher.TeacherContact.PinterestUserName,
                TwitterUserName = teacher.TeacherContact.TwitterUserName,
                Skills = Skills,
                Percents = Percents
            };

            return View(teacherDetailVM);
        }
    }
}
