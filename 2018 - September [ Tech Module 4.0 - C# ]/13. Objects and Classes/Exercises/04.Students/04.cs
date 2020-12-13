using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] commands = Console.ReadLine().Split();

                string firstName = commands[0];
                string lastName = commands[1];
                double grade = double.Parse(commands[2]);

                Student currentStudent = new Student(firstName, lastName, grade);

                students.Add(currentStudent);
            }

            PrintStudent(students);
        }

        private static void PrintStudent(List<Student> students)
        {
            foreach (Student student in students.OrderByDescending(s => s.Grade))
            {
                Console.WriteLine(student);
            }
        }
    }

    class Student
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

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }
}