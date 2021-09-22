using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.ViewModels
{
    public class RegisterVM
    {
        [Required, StringLength(255)]
        public string Fullname { get; set; }
        [Required, StringLength(20)]
        public string Username { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
