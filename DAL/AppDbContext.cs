using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EduHome.Models;

namespace EduHome.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseImage> CourseImage { get; set; }
    }
}
