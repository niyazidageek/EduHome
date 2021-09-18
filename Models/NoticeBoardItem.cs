using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class NoticeBoardItem:BaseEntity
    {
        [Required]
        public DateTime? Date { get; set; }
        [Required, StringLength(300)]
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
    }
}
