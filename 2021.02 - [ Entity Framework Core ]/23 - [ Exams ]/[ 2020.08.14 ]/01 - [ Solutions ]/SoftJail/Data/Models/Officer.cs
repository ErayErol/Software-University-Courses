using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SoftJail.Data.Models.Enums;

namespace SoftJail.Data.Models
{
    public class Officer
    {
        public Officer()
        {
            this.OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public decimal Salary { get; set; }
        
        [Required]
        public Position Position { get; set; }

        [Required]
        public Weapon Weapon { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public Department Department { get; set; }

        public virtual ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }

    }
}

// •	Id – integer, Primary Key
// •	FullName – text with min length 3 and max length 30 (required)
// •	Salary – decimal (non-negative, minimum value: 0) (required)
// •	Position - Position enumeration with possible values: “Overseer, Guard, Watcher, Labour” (required)
// •	Weapon - Weapon enumeration with possible values: “Knife, FlashPulse, ChainRifle, Pistol, Sniper” (required)
// •	DepartmentId - integer, foreign key (required)
// •	Department – the officer's department (required)
// •	OfficerPrisoners - collection of type OfficerPrisoner
// 