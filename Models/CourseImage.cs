using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class CourseImage:BaseEntity
    {
        [Required, StringLength(255)]
        public string Photo { get; set; }
    }
}
