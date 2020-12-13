using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ToDoDbContext : DbContext
    {
        public virtual DbSet<Task> Tasks { get; set; }

        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=ToDoList;Integrated Security=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}