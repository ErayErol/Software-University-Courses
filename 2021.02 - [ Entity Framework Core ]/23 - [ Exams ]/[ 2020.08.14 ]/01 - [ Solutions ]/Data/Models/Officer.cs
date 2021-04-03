namespace SoftJail.Data.Models
{
    using SoftJail.Data.Models.Enums;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Officer
    {
        public Officer()
        {
            this.OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }

        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public decimal Salary { get; set; }
        
        public Position Position { get; set; }

        public Weapon Weapon { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public virtual ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
    }
}