using System;
using Microsoft.AspNetCore.Identity;

namespace EduHome.Models
{
    public class AppUser: IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsEnabled { get; set; }
    }
}
