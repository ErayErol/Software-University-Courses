namespace Demo.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.ComponentModel.DataAnnotations;

    [Index(nameof(QuestionId), Name = "IX_QuestionId123")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
