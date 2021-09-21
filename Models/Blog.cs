using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Blog:BaseEntity
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required,StringLength(150)]
        public string AuthorFullName { get; set; }
        [Required]
        public DateTime? PostDate { get; set; }
        [Required, StringLength(1300)]
        public string Content { get;    set; }
        [Required]
        public bool IsDeleted { get; set; }
        public BlogImage BlogImage { get; set; }
        public IList<BlogCategory> BlogCategories { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
