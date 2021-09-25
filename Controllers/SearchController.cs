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

        public IActionResult GetSearchResult(string input)
        {
            

            var Teachers = _context.Teachers.Where(t => t.IsDeleted == false)
                .Include(t => t.TeacherImage)
                .Where(t=>t.FullName.Contains(input))
                .ToList();

            var Events = _context.Events.Where(e => e.IsDeleted == false)
                .Include(e => e.EventImage)
                .Where(e => e.Name.Contains(input))
                .ToList();

            SearchVM searchVM = new SearchVM()
            {
                Teachers = Teachers,
                Events = Events
            };

            return PartialView("_SearchPartialView",searchVM);
        }
    }
}
