using System;
using Code_First.Models;

namespace Code_First
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();
        }
    }
}
