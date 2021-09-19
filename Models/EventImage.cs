using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class EventImage:BaseEntity
    {
        [Required]
        public string Photo { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
