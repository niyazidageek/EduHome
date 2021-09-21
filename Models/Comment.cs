using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Comment:BaseEntity
    {
        [Required, StringLength(255)]
        public string FullName { get; set; }
        [Required, StringLength(255)]
        public string Mail { get; set; }
        [Required, StringLength(255)]
        public string Subject { get; set; }
        [Required, StringLength(1200)]
        public string Message { get; set; }
        public Blog Blog { get; set; }
    }
}
