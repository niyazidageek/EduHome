using System;
using System.Collections.Generic;
using EduHome.Models;

namespace EduHome.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Course> Courses { get; set; }
        public List<Event> Events { get; set; }
    }
}
