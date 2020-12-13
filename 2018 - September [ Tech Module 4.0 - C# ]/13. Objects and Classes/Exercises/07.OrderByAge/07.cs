using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> people = new List<People>();

            while (true)
            {
                string[] currentPerson = Console.ReadLine().Split();

                if (currentPerson[0] == "End")
                {
                    break;
                }

                string name = currentPerson[0];
                string id = currentPerson[1];
                int age = int.Parse(currentPerson[2]);

                People person = new People(name, id, age);

                people.Add(person);
            }

            PrintPerson(people);
        }

        private static void PrintPerson(List<People> people)
        {
            foreach (People person in people.OrderBy(p => p.Age))
            {
                person.Print(person);
            }
        }
    }

    class People
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public int Age { get; set; }

        public People(string name, string id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }

        public void Print(People person)
        {
            Console.WriteLine(person);
        }
    }
}