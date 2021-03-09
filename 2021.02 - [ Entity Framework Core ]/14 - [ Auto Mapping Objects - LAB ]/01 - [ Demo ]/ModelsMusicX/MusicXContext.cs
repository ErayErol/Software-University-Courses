using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Demo.ModelsMusicX
{
    public partial class MusicXContext : DbContext
    {
        public MusicXContext()
        {
        }

        public MusicXContext(DbContextOptions<MusicXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtistMetadatum> ArtistMetadata { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<SongArtist> SongArtists { get; set; }
        public virtual DbSet<SongMetadatum> SongMetadata { get; set; }
        public virtual DbSet<Source> Sources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=MusicX");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted, "IX_Artists_IsDeleted");
            });

            modelBuilder.Entity<ArtistMetadatum>(entity =>
            {
                entity.HasIndex(e => e.ArtistId, "IX_ArtistMetadata_ArtistId");

                entity.HasIndex(e => e.IsDeleted, "IX_ArtistMetadata_IsDeleted");

                entity.HasIndex(e => e.SourceId, "IX_ArtistMetadata_SourceId");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistMetadata)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.ArtistMetadata)
                    .HasForeignKey(d => d.SourceId);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted, "IX_Songs_IsDeleted");

                entity.HasIndex(e => e.SourceId, "IX_Songs_SourceId");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.SourceId);
            });

            modelBuilder.Entity<SongArtist>(entity =>
            {
                entity.HasIndex(e => e.ArtistId, "IX_SongArtists_ArtistId");

                entity.HasIndex(e => e.IsDeleted, "IX_SongArtists_IsDeleted");

                entity.HasIndex(e => e.SongId, "IX_SongArtists_SongId");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.SongArtists)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongArtists)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SongMetadatum>(entity =>
            {
                entity.HasIndex(e => e.IsDeleted, "IX_SongMetadata_IsDeleted");

                entity.HasIndex(e => e.SongId, "IX_SongMetadata_SongId");

                entity.HasIndex(e => e.SourceId, "IX_SongMetadata_SourceId");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongMetadata)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.SongMetadata)
                    .HasForeignKey(d => d.SourceId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
