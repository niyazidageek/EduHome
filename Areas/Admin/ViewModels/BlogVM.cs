using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EduHome.Models;
using Microsoft.AspNetCore.Http;

namespace EduHome.Areas.Admin.ViewModels
{
    public class BlogVM
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, StringLength(150)]
        public string AuthorFullName { get; set; }
        [Required]
        public DateTime? PostDate { get; set; }
        [Required, StringLength(1300)]
        public string Content { get; set; }
        public IFormFile Photo { get; set; }
        public List<string> CategoriesInput { get; set; }
        public List<CategoryVM> Categories { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
