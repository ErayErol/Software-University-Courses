using System;
using Microsoft.EntityFrameworkCore;
using RealEstates.Data;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();
        }
    }
}
