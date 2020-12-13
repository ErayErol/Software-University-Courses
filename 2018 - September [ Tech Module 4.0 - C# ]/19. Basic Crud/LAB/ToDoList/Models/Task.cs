using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Comments { get; set; }
    }
}