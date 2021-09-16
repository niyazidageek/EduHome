using System;
using System.Collections.Generic;

namespace EduHome.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public List<CourseCategory> CourseCategories { get; set; }
    }
}
