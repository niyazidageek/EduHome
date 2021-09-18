using System;
namespace EduHome.Models
{
    public class EventCategory:BaseEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
