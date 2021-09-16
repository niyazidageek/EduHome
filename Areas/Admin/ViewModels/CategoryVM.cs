using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Areas.Admin.ViewModels
{
    public class CategoryVM
    {
        public List<string> Names { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
