using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class TeacherImage:BaseEntity
    {
        [Required, StringLength(255)]
        public string Photo { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
