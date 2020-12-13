using System;
using System.Collections.Generic;

namespace _05.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands[0] == "end")
                {
                    break;
                }

                string firstName = commands[0];
                string lastName = commands[1];
                int age = int.Parse(commands[2]);
                string town = commands[3];

                Student student = new Student(firstName, lastName,age,town);

                students.Add(student);
            }

            string homeTown = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.City == homeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public Student(string firstName, string lastName, int age, string town)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.City = town;
        }
    }
}