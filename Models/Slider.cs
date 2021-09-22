using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Slider:BaseEntity
    {
        [Required, StringLength(300)]
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ButtonText { get; set; }
    }
}
