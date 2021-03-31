using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Department
    {
        public Department()
        {
            this.Cells = new HashSet<Cell>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Cell> Cells { get; set; }

        // TODO: public ICollection<Officer> Officers { get; set; }
        // public ICollection<Officer> Officers { get; set; }

    }
}

// •	Id – integer, Primary Key
// •	Name – text with min length 3 and max length 25 (required)
// •	Cells - collection of type Cell
// 