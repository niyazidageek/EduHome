using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduHome.Models;
using Microsoft.AspNetCore.Http;

namespace EduHome.Areas.Admin.ViewModels
{
    public class EventVM
    {
        public List<CategoryVM> Categories { get; set; }
        public List<SpeakerVM> Speakers { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }
        [Required, StringLength(50)]
        public string Venue { get; set; }
        [Required, StringLength(500)]
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
        public List<string> CategoriesInput { get; set; }
        public List<string> SpeakersInput { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
