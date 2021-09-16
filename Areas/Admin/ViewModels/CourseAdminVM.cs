using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduHome.Models;
using Microsoft.AspNetCore.Http;

namespace EduHome.Areas.Admin.ViewModels
{
    public class CourseAdminVM
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
        public IFormFile Photo { get; set; }
        public List<LanguageVM> Languages { get; set; }
        public List<CategoryVM> Categories { get; set; }
    }
}
