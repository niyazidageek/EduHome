using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Teacher:BaseEntity
    {
        public bool IsDeleted { get; set; }
        [Required, StringLength(255)]
        public string FullName { get; set; }
        [Required, StringLength(50)]
        public string Position { get; set; }
        [Required, StringLength(1000)]
        public string Info { get; set; }
        [Required, StringLength(500)]
        public string Degree { get; set; }
        [Required, StringLength(50)]
        public string Experience { get; set; }
        [Required, StringLength(50)]
        public string Hobbies { get; set; }
        [Required, StringLength(50)]
        public string Faculty { get; set; }
        public IList<TeacherSkill> TeacherSkills { get; set; }
        public TeacherContact TeacherContact { get; set; }
        public TeacherImage TeacherImage { get; set; }
    }
}
