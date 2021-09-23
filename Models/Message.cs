using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Message:BaseEntity
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(100)]
        public string Subject { get; set; }
        [Required, StringLength(2000)]
        public string Text { get; set; }
    }
}
