using System;
using System.Linq;
using Demo.Models;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new GeographyContext();
            var moutains = db.Mountains.Select(x => new { x.Id, x.MountainRange }).ToList();
            foreach (var i in moutains)
            {
                Console.WriteLine(i);
            }
        }
    }
}
