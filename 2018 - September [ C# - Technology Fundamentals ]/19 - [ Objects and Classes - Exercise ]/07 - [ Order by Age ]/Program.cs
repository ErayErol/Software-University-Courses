using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            var personsList = new List<PersonInfo>();

            while ((input = Console.ReadLine()) != "End")
            {
                var splitInput = input
                    .Split()
                    .ToList();

                string name = splitInput[0];
                string ID = splitInput[1];
                int age = int.Parse(splitInput[2]);

                PersonInfo personInfo = new PersonInfo(name, ID, age);

                personsList.Add(personInfo);
            }

            foreach (var person in personsList.OrderBy(x => x.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }
    }

    class PersonInfo
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public PersonInfo(string name, string ID, int age)
        {
            this.Name = name;
            this.ID = ID;
            this.Age = age;
        }
    }
}
