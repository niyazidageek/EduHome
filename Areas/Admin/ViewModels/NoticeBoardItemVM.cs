using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Areas.Admin.ViewModels
{
    public class NoticeBoardItemVM
    {
        [Required, StringLength(300)]
        public string Message { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        public int NoticeBoardItemId { get; set; }
    }
}
