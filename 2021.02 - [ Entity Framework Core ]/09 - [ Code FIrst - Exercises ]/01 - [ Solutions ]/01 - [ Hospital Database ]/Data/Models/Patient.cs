namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Patient
    {
        public Patient()
        {
            Prescriptions = new HashSet<PatientMedicament>();
            Diagnoses = new HashSet<Diagnose>();
            Visitations = new HashSet<Visitation>();
        }

        [Key]
        public int PatientId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
        public virtual ICollection<Diagnose> Diagnoses { get; set; }
        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}