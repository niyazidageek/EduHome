using System;
using System.Collections.Generic;
using EduHome.Models;
using X.PagedList;

namespace EduHome.ViewModels
{
    public class CourseVM
    {
        public IPagedList<Course> Courses { get; set; }
    }
}
