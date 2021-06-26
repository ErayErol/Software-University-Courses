namespace SharedTrip.Data
{
    using Microsoft.EntityFrameworkCore;

    using SharedTrip.Data.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public DbSet<User> Users { get; init; }

        public DbSet<Trip> Trips { get; init; }

        public DbSet<UserTrip> UserTrips { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>().HasKey(table => new { table.UserId, table.TripId });
        }
    }
}