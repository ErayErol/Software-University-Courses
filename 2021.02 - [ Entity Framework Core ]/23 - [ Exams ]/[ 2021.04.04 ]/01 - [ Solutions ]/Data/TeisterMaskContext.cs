namespace TeisterMask.Data
{
    using TeisterMask.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }


        public virtual DbSet<Employee> Employees { get; set; }
        
        public virtual DbSet<EmployeeTask> EmployeesTasks { get; set; }
        
        public virtual DbSet<Task> Tasks { get; set; }
        
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>().HasKey(table => new { table.EmployeeId, table.TaskId });
        }
    }
}