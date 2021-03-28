namespace Demo
{
    using Demo.Models;

    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            var emp = db.Employees
                .GroupBy(x => x.Salary)
                .ToList();

            foreach (var e in emp)
            {
                Console.WriteLine($"{e.Key}");
            }
        }
    }
}
