using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class TeacherContact:BaseEntity
    {
        [Required, StringLength(255)]
        public string Mail { get; set; }
        [Required, StringLength(255)]
        public string Phone { get; set; }
        [Required, StringLength(255)]
        public string SkypeUserName { get; set; }
        [Required, StringLength(255)]
        public string FacebookUserName { get; set; }
        [Required, StringLength(255)]
        public string PinterestUserName { get; set; }
        [Required, StringLength(255)]
        public string TwitterUserName { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
