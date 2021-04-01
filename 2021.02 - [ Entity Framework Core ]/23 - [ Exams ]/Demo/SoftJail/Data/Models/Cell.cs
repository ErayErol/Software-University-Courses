using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Cell
    {
        public Cell()
        {
            this.Prisoners = new HashSet<Prisoner>();
        }

        [Key]
        public int Id { get; set; }

        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Prisoner> Prisoners { get; set; }
    }
}

// •	Id – integer, Primary Key
// •	CellNumber – integer in the range [1, 1000] (required)
// •	HasWindow – bool (required)
// •	DepartmentId - integer, foreign key (required)
// •	Department – the cell's department (required)
// •	Prisoners - collection of type Prisoner
// 