using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Speaker:BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Position { get; set; }
        public bool IsDeleted { get; set; }
        public SpeakerImage SpeakerImage { get; set; }
        public IList<SpeakerEvent> SpeakerEvents { get; set; }
    }
}
