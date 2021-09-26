using System;
using System.Collections.Generic;
using EduHome.Models;

namespace EduHome.ViewModels
{
    public class SearchVM
    {
        public List<Teacher> Teachers { get; set; }
        public List<Event> Events { get; set; }
        public List<Course> Courses { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
