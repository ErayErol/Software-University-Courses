using System;
using System.Linq;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Microsoft.EntityFrameworkCore.SqlServer
            // Microsoft.EntityFrameworkCore.Design

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
