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
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<NoticeBoardItem> NoticeBoardItems { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerImage> SpeakerImage { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
        public DbSet<EventImage> EventImage { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherImage> TeacherImage { get; set; }
        public DbSet<TeacherContact> TeacherContact { get; set; }
        public DbSet<TeacherSkill> TeacherSkills { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImage { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}
