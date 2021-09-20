using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduHome.Models;
using Microsoft.AspNetCore.Http;

namespace EduHome.Areas.Admin.ViewModels
{
    public class TeacherVM
    {
        [Required, StringLength(255)]
        public string Fullname { get; set; }
        [Required, StringLength(50)]
        public string Position { get; set; }
        [Required, StringLength(500)]
        public string Info { get; set; }
        [Required, StringLength(50)]
        public string Degree { get; set; }
        [Required, StringLength(50)]
        public string Experience { get; set; }
        [Required, StringLength(50)]
        public string Hobbies { get; set; }
        [Required, StringLength(50)]
        public string Faculty { get; set; }
        [Required, StringLength(255)]
        public string Mail { get; set; }
        [Required, StringLength(255)]
        public string Phone { get; set; }
        [Required, StringLength(255)]
        public string SkypeUserName { get; set; }
        [Required, StringLength(255)]
        public string FacebookUserName { get; set; }
        [Required, StringLength(255)]
        public string PinterestUserName { get; set; }
        [Required, StringLength(255)]
        public string TwitterUserName { get; set; }
        public int TeacherId { get; set; }
        public IFormFile Photo { get; set; }
        public List<SkillVM> Skills { get; set; }
        public List<string> SkillsInput { get; set; }
        public List<int> PercentagesInput { get; set; }
        public int Count { get; set; }
    }
}
