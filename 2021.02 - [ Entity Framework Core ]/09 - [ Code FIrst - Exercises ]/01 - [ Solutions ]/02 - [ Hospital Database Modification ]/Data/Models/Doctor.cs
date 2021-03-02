namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Doctor
    {
        public Doctor()
        {
            Visitations = new HashSet<Visitation>();
        }

        [Key]
        public int DoctorId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Specialty { get; set; }

        public virtual ICollection<Visitation> Visitations{ get; set; }
    }
}