using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Areas.Admin.ViewModels
{
    public class SkillVM
    {
        [Required]
        public string Name { get; set; }
        public int SkillId { get; set; }
    }
}
