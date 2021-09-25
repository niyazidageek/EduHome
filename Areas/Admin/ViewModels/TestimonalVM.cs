using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EduHome.Areas.Admin.ViewModels
{
    public class TestimonalVM
    {
        [Required, StringLength(500)]
        public string Text { get; set; }
        [Required, StringLength(255)]
        public string Fullname { get; set; }
        [Required, StringLength(255)]
        public string Position { get; set; }
        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}
