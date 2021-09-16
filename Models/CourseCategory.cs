using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class CourseCategory:BaseEntity
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
