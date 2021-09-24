using System;
using EduHome.Models;
using X.PagedList;

namespace EduHome.ViewModels
{
    public class BlogVM
    {
        public IPagedList<Blog> Blogs { get; set; }
    }
}
