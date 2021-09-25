using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Testimonal:BaseEntity
    {
        [Required, StringLength(255)]
        public string PersonPhoto { get; set; }
        [Required, StringLength(500)]
        public string Text { get; set; }
        [Required, StringLength(255)]
        public string Fullname { get; set; }
        [Required, StringLength(255)]
        public string Position { get; set; }
    }
}
