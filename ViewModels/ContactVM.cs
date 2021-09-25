using System;
using System.ComponentModel.DataAnnotations;
using EduHome.Models;

namespace EduHome.ViewModels
{
    public class ContactVM
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(100)]
        public string Subject { get; set; }
        [Required, StringLength(2000)]
        public string Message { get; set; }
        public Contact Contact { get; set; }
    }
}
