using System;
using System.Collections.Generic;

namespace EduHome.ViewModels
{
    public class CourseDetailVM
    {

        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ApplicationRule { get; set; }
        public string Certification { get; set; }
        public DateTime? StartDate { get; set; }
        public string Duration { get; set; }
        public string ClassDuration { get; set; }
        public string SkillLevel { get; set; }
        public string Language { get; set; }
        public int? StudentCapacity { get; set; }
        public string Assesment { get; set; }
        public float? Fee { get; set; }
        public List<string> Categories { get; set; }

    }
}
