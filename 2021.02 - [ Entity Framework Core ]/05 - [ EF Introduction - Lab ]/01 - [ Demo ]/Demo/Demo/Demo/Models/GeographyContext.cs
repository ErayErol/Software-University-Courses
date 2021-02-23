using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Demo.Models
{
    public partial class GeographyContext : DbContext
    {
        public GeographyContext()
        {
        }

        public GeographyContext(DbContextOptions<GeographyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<CountriesRiver> CountriesRivers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Mountain> Mountains { get; set; }
        public virtual DbSet<MountainsCountry> MountainsCountries { get; set; }
        public virtual DbSet<Peak> Peaks { get; set; }
        public virtual DbSet<River> Rivers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=Geography");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.HasKey(e => e.ContinentCode);

                entity.Property(e => e.ContinentCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ContinentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CountriesRiver>(entity =>
            {
                entity.HasKey(e => new { e.CountryCode, e.RiverId });

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.CountriesRivers)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CountriesRivers_Countries");

                entity.HasOne(d => d.River)
                    .WithMany(p => p.CountriesRivers)
                    .HasForeignKey(d => d.RiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CountriesRivers_Rivers");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryCode);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Capital)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ContinentCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IsoCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.ContinentCodeNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.ContinentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Countries_Continents");

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.CurrencyCode)
                    .HasConstraintName("FK_Countries_Currencies");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.CurrencyCode);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Mountain>(entity =>
            {
                entity.Property(e => e.MountainRange)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MountainsCountry>(entity =>
            {
                entity.HasKey(e => new { e.MountainId, e.CountryCode })
                    .HasName("PK_MountainsContinents");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.MountainsCountries)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MountainsCountries_Countries");

                entity.HasOne(d => d.Mountain)
                    .WithMany(p => p.MountainsCountries)
                    .HasForeignKey(d => d.MountainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MountainsCountries_Mountains");
            });

            modelBuilder.Entity<Peak>(entity =>
            {
                entity.Property(e => e.PeakName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Mountain)
                    .WithMany(p => p.Peaks)
                    .HasForeignKey(d => d.MountainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Peaks_Mountains");
            });

            modelBuilder.Entity<River>(entity =>
            {
                entity.Property(e => e.Outflow)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RiverName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
