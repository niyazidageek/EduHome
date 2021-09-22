using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Subscriber:BaseEntity
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
