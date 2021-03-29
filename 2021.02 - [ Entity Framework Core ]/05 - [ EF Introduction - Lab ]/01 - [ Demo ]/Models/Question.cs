namespace Demo.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
