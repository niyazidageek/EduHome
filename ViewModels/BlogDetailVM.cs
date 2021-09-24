using System;
using System.Collections.Generic;
using EduHome.Models;

namespace EduHome.ViewModels
{
    public class BlogDetailVM
    {
        public Blog Blog { get; set; }
        public List<Blog> Blogs { get; set; }
        public Comment Comment { get; set; }
        public int BlogId { get; set; }
    }
}
