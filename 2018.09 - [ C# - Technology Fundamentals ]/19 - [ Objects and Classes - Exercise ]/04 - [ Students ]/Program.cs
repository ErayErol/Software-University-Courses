using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            var studentsList = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                Student student = new Student(firstName, lastName, grade);

                studentsList.Add(student);
            }

            studentsList = studentsList
                .OrderByDescending(x => x.Grade)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, studentsList.Select(x => $"{x.FirstName} {x.LastName}: {x.Grade:f2}")));
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
    }
}
