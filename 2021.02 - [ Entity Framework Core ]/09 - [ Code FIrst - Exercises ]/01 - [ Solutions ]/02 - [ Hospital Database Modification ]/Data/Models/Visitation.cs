namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Visitation
    {
        [Key]
        public int VisitationId { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}