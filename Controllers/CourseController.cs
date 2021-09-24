﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace EduHome.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? number)
        {
            var Courses =  _context.Courses.Where(c => c.IsDeleted == false)
                .OrderByDescending(c => c.Id)
                .Include(c => c.CourseImage)
                .ToList()
                .ToPagedList(number ?? 1, 12);
            CourseVM courseVM = new CourseVM
            {
                Courses = Courses
            };

            return View(courseVM);
        }
    }
}
