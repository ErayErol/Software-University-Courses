using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Range(1 , double.MaxValue)]
        public double Price { get; set; }
    }
}