using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Areas.Admin.ViewModels;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly AppDbContext _context;

        public SkillController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Skill> Skills = await _context.Skills.Where(s=>s.IsDeleted == false).ToListAsync();
            return View(Skills);
        }

        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(SkillVM skillVM)
        {
            if (!ModelState.IsValid) return View(skillVM);

            bool skillExists = _context.Skills.ToList().Exists(s=>s.Name.ToLower() == skillVM.Name.ToLower());

            if (skillExists)
            {
                ModelState.AddModelError("", "Skill already exists");
                return View(skillVM);
            }

            Skill skill = new Skill
            {
                Name = skillVM.Name,
                IsDeleted = false
            };

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditSkill(int id)
        {
            var skill = await _context.Skills.Where(s => s.IsDeleted == false).FirstOrDefaultAsync(s => s.Id == id);
            if (skill == null) return NotFound();

            SkillVM skillVM = new SkillVM
            {
                Name = skill.Name,
                SkillId = skill.Id
            };

            return View(skillVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditSkill(SkillVM skillVM)
        {
            if (!ModelState.IsValid) return View(skillVM);

            var skill = await _context.Skills.Where(s => s.IsDeleted == false).FirstOrDefaultAsync(s => s.Id == skillVM.SkillId);
            if (skill == null) return NotFound();

            bool skillExists = _context.Skills.ToList().Exists(s => s.Name.ToLower() == skillVM.Name.ToLower());

            if (skillExists)
            {
                ModelState.AddModelError("", "Skill already exists");
                return View(skillVM);
            }

            skill.Name = skillVM.Name;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteSkill(int id)
        {
            var skill = await _context.Skills.Where(s => s.IsDeleted == false).FirstOrDefaultAsync(s => s.Id == id);
            if (skill == null) return NotFound();
            skill.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
