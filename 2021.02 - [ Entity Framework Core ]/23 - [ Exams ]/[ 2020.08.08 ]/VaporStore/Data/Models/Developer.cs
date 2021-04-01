using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class Developer
    {
        public Developer()
        {
            this.Games = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }

    }
}

// •	Id – integer, Primary Key
// •	Name – text (required)
// •	Games - collection of type Game
// 