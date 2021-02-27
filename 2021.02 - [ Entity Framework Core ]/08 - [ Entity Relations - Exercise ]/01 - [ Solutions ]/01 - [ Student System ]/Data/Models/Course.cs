namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        public Course()
        {
            Resources = new HashSet<Resource>();
            HomeworkSubmissions = new HashSet<Homework>();
            StudentsEnrolled = new HashSet<StudentCourse>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required] 
        public decimal Price { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }

        public virtual ICollection<StudentCourse> StudentsEnrolled { get; set; }

    }
}