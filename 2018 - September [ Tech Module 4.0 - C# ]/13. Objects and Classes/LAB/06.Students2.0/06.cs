using System;
using System.Collections.Generic;

namespace _06.Students2._0
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

                string currentFirstName = commands[0];
                string currentLastName = commands[1];
                int currentAge = int.Parse(commands[2]);
                string currentCity = commands[3];

                var currentStudent = new Student(currentFirstName, currentLastName, currentAge, currentCity);

                bool exist = false;

                foreach (Student student in students)
                {
                    if (student.FirstName == currentStudent.FirstName && student.LastName == currentStudent.LastName)
                    {
                        student.Age = currentStudent.Age;
                        student.City = currentStudent.City;

                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    students.Add(currentStudent);  
                }
            }

            string homeTown = Console.ReadLine();

            foreach (var student in students)
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

        public Student(string currentFirstName, string currentLastName, int currentAge, string currentCity)
        {
            this.FirstName = currentFirstName;
            this.LastName = currentLastName;
            this.Age = currentAge;
            this.City = currentCity;
        }
    }
}