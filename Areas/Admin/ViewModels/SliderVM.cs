using System;
using EduHome.Models;
using Microsoft.AspNetCore.Http;

namespace EduHome.Areas.Admin.ViewModels
{
    public class SliderVM
    {
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ButtonText { get; set; }
        public int SliderId { get; set; }
        public Slider Slider { get; set; }
    }
}
