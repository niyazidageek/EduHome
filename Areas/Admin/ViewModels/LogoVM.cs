using System;
using Microsoft.AspNetCore.Http;

namespace EduHome.Areas.Admin.ViewModels
{
    public class LogoVM
    {
        public IFormFile Photo { get; set; }
        public string Image { get; set; }
    }
}
