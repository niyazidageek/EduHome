using System;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class SpeakerImage:BaseEntity
    {
        [Required]
        public string Photo { get; set; }
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
    }
}
