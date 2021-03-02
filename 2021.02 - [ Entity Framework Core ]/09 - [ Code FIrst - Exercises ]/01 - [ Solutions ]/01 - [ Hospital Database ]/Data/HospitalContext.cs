namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>()
                .HasKey(sc => new
                {
                    sc.PatientId,
                    sc.MedicamentId
                });

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
    }

    public static class Configuration
    {
        public const string ConnectionString = "Server=.;Database=StudentSystem;Integrated Security=true";
    }
}