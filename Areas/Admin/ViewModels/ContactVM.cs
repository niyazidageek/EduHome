using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Areas.Admin.ViewModels
{
    public class ContactVM
    {
        [Required, StringLength(255)]
        public string Address { get; set; }
        [Required, StringLength(255)]
        public string Phone1 { get; set; }
        [Required, StringLength(255)]
        public string Phone2 { get; set; }
        [Required, StringLength(255)]
        public string Email { get; set; }
        [Required, StringLength(255)]
        public string WebSite { get; set; }
    }
}
