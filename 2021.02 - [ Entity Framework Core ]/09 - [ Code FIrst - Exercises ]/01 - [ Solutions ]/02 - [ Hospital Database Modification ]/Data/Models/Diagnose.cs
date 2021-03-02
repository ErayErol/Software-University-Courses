namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Diagnose
    {
        [Key]
        public int DiagnoseId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}