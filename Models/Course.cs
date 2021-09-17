using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Course:BaseEntity
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Title { get; set; }
        [Required, StringLength(500)]
        public string Description { get; set; }
        [Required, StringLength(255)]
        public string ApplicationRule { get; set; }
        [Required, StringLength(255)]
        public string Certification { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required, StringLength(50)]
        public string Duration { get; set; }
        [Required, StringLength(50)]
        public string ClassDuration { get; set; }
        [Required, StringLength(50)]
        public string SkillLevel { get; set; }
        [Required, StringLength(50)]
        public string Language { get; set; }
        [Required]
        public int? StudentCapacity { get; set; }
        [Required, StringLength(50)]
        public string Assesment { get; set; }
        [Required]
        public float? Fee { get; set; }
        [Required]
        public CourseImage CourseImage { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public IList<CourseCategory> CourseCategories { get; set; }
    }
}
