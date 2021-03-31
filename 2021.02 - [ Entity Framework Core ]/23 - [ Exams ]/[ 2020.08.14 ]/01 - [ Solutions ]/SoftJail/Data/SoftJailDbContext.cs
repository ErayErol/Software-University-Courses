using SoftJail.Data.Models;

namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;

    public class SoftJailDbContext : DbContext
    {
        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Prisoner> Prisoners { get; set; }

        public virtual DbSet<Cell> Cells { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Mail> Mails { get; set; }

        public virtual DbSet<Officer> Officers { get; set; }

        public virtual DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OfficerPrisoner>()
                .HasKey(table => new { table.OfficerId, table.PrisonerId });

            // FK_OfficersPrisoners_Officers_OfficerId
            //builder.Entity<Officer>()
            //    .HasMany(x => x.OfficerPrisoners)
            //    .WithOne(x => x.Officer)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}