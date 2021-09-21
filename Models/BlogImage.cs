using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class BlogImage:BaseEntity
    {
        [Required, StringLength(255)]
        public string Photo { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
