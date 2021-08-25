namespace Git.Data
{
    using Git.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class GitDbContext : DbContext
    {
        public DbSet<User> Users { get; init; }

        public DbSet<Repository> Repositories { get; init; }

        public DbSet<Commit> Commits { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Git;Integrated Security=True;");
            }
        }
    }
}