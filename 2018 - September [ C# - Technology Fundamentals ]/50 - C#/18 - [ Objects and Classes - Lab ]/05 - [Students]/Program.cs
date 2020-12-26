using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var studentsList = new List<Student>();

            while ((input = Console.ReadLine()) != "end")
            {
                var inputSplitted = input
                    .Split()
                    .ToList();

                string firstName = inputSplitted[0];
                string lastName = inputSplitted[1];
                int age = int.Parse(inputSplitted[2]);
                string hometown = inputSplitted[3];

                Student student = new Student();

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;
                student.Hometown = hometown;

                studentsList.Add(student);
            }

            string city = Console.ReadLine();

            studentsList = studentsList
                .Where(x => x.Hometown == city)
                .ToList();

            foreach (Student student in studentsList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
    }
}
