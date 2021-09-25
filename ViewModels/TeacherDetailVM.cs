using System;
using System.Collections.Generic;
using EduHome.Models;

namespace EduHome.ViewModels
{
    public class TeacherDetailVM
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Info { get; set; }
        public string Degree { get; set; }
        public string Experience { get; set; }
        public string Hobbies { get; set; }
        public string Faculty { get; set; }
        public string Photo { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string SkypeUserName { get; set; }
        public string FacebookUserName { get; set; }
        public string PinterestUserName { get; set; }
        public string TwitterUserName { get; set; }
        public List<string> Skills { get; set; }
        public List<string> Percents { get; set; }
    }
}
