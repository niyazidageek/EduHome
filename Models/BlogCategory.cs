using System;
namespace EduHome.Models
{
    public class BlogCategory:BaseEntity
    {
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
