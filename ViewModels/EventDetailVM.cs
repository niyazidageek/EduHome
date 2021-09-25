using System;
using System.Collections.Generic;
using EduHome.Models;

namespace EduHome.ViewModels
{
    public class EventDetailVM
    {
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; } 
        public string Venue { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public List<string> Categories { get; set; }
        public List<Speaker> Speakers { get; set; }
    }
}
