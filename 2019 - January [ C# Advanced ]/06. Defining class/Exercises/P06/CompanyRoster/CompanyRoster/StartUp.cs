using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string name = commands[0];
                decimal salary = decimal.Parse(commands[1]);
                string position = commands[2];
                string department = commands[3];

                Employee employee = new Employee(name, salary, position, department);

                if (commands.Length == 5)
                {
                    if (commands[4].Contains('@'))
                    {
                        employee.Email = commands[4];
                    }
                    else
                    {
                        employee.Age = int.Parse(commands[4]);
                    }
                }
                else if (commands.Length == 6)
                {
                    employee.Email = commands[4];
                    employee.Age = int.Parse(commands[5]);
                }

                employees.Add(employee);
            }

            var topDepartment = employees
                .GroupBy(x => x.Department)
                .ToDictionary(x => x.Key, y => y.Select(s => s))
                .OrderByDescending(x => x.Value.Average(s => s.Salary))
                .FirstOrDefault();

            var top = employees.GroupBy(x => x.Name).ToDictionary(x => x.Key, z => z.Select(s => s))
                .OrderByDescending(x => x.Value.Max(y => y.Salary)).ToList();

            foreach (var kvp in top)
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var kv in kvp.Value.OrderByDescending(x => x.Age))
                {
                    Console.WriteLine(kv.Name);
                }
            }

            Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");

            foreach (Employee employee in topDepartment.Value.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}
