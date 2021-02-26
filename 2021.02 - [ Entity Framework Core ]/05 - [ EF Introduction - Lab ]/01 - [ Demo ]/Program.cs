using System;
using System.Linq;
using Demo.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SliDoDbContext();
            db.Database.Migrate();
        }
    }
}
