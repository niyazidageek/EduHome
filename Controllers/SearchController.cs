using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace EduHome.Controllers
{
    public class SearchController : Controller
    {
        public AppDbContext _context { get; }
        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetGlobalSearchResult(string input)
        {
            

            var Teachers = _context.Teachers.Where(t => t.IsDeleted == false)
                .Where(t=>t.FullName.Contains(input))
                .ToList();

            var Events = _context.Events.Where(e => e.IsDeleted == false)
                .Where(e => e.Name.Contains(input))
                .ToList();

            var Courses = _context.Courses.Where(c => c.IsDeleted == false)
                .Where(c => c.Name.Contains(input))
                .ToList();

            var Blogs = _context.Blogs.Where(b => b.IsDeleted == false)
                .Where(b => b.Name.Contains(input))
                .ToList();

            SearchVM searchVM = new SearchVM()
            {
                Teachers = Teachers,
                Events = Events,
                Courses = Courses,
                Blogs = Blogs
            };

            return PartialView("_SearchGlobalPartialView",searchVM);
        }

        public IActionResult GetCoursesSearchResult(string input)
        {
            var Courses = _context.Courses.Where(c => c.IsDeleted == false)
                .Where(c => c.Name.Contains(input))
                .ToList();

            return PartialView("_SearchCoursesPartialView", Courses);
        }
    }
}
