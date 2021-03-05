using System;
using Demo.ModelsSoftUni;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            var query = "Marketing Specialist";
            var employees = db.Employees.FromSqlInterpolated($"SELECT * FROM Employees WHERE JobTitle = {query}");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName);
            }
        }
    }
}
