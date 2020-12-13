using Microsoft.EntityFrameworkCore;
using TeisterMask.Models;

namespace TeisterMask.Data
{
    public class TeisterMaskDbContext : DbContext
    {
        public virtual DbSet<Task> Tasks { get; set; }

        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=TeisterMask;Integrated Security=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}