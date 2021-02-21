using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Code_First.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=CodeFirstDemo2021");
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }
            
        public DbSet<News> News { get; set; }
    }
}
