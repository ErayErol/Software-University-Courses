using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
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
