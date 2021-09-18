using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Category:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public IList<CourseCategory> CourseCategories { get; set; }
    }
}
