using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EduHome.Areas.Admin.ViewModels;
using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.Admin.ViewComponents
{
    public class TeacherSkillViewComponent: ViewComponent
    {
        public AppDbContext _context { get; }
        public TeacherSkillViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            TeacherVM tvm = new TeacherVM();
            tvm.Skills = new List<SkillVM>();
            tvm.Count = count;
            List<Skill> Skills = await _context.Skills.Where(c => c.IsDeleted == false).ToListAsync();
            foreach (var skill in Skills)
            {
                tvm.Skills.Add(new SkillVM { Name = skill.Name });
            }

            return View((await Task.FromResult(tvm)));
        }
    }
}
