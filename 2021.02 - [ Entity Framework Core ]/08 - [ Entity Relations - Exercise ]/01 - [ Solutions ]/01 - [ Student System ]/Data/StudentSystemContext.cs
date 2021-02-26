using System;

namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasColumnType("char")
                .IsUnicode(false);

            //modelBuilder
            //    .Entity<Resource>()
            //    .Property(e => e.ResourceType)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (ResourceType)Enum.Parse(typeof(ResourceType), v));

            modelBuilder.Entity<Homework>()
                .Property(s => s.Content)
                .IsUnicode(false);

            //modelBuilder
            //    .Entity<Homework>()
            //    .Property(e => e.ContentType)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (ContentType)Enum.Parse(typeof(ContentType), v));

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(s => s.StudentsEnrolled)
                .HasForeignKey(sc => sc.CourseId);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

    }

    public static class Configuration
    {
        public const string ConnectionString = "Server=.;Database=StudentSystem;Integrated Security=true";
    }
}
