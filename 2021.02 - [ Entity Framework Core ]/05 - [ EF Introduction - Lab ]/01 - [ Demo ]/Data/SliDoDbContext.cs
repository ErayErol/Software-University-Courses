using System;
using System.Collections.Generic;
using System.Text;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class SliDoDbContext : DbContext
    {
        private const string Connection = "Server=.;Database=SliDo;Integrated Security=true";

        public SliDoDbContext()
        {
        }

        public SliDoDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(Connection);
            }
        }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
