using System;
using System.ComponentModel.DataAnnotations;
using EduHome.Models;
using Microsoft.AspNetCore.Http;

namespace EduHome.Areas.Admin.ViewModels
{
    public class SpeakerVM
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Position { get; set; }
        public IFormFile Photo { get; set; }
        public int SpeakerId { get; set; }
        public string Image { get; set; }
    }
}
