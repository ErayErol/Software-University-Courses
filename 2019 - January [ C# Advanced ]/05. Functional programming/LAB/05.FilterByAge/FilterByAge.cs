namespace _05.FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FilterByAge
    {
        public class Person
        {
            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            public string Name { get; set; }

            public int Age { get; set; }
        }

        public static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                var line = Console.ReadLine();
                var parts = line.Split(", ");
                string name = parts[0];
                int age = int.Parse(parts[1]);
                var person = new Person(name, age);
                people.Add(person);
            }

            string condition = Console.ReadLine();
            int searchedAge = int.Parse(Console.ReadLine());
            Func<Person, bool> predicate = p => true;

            if (condition == "older")
            {
                predicate = p => p.Age >= searchedAge;
            }
            else if (condition == "younger")
            {
                predicate = p => p.Age < searchedAge;
            }

            var filterPeople = people.Where(predicate);
            string format = Console.ReadLine();

            foreach (var person in filterPeople)
            {
                var output = format
                    .Replace("age", person.Age.ToString())
                    .Replace("name", person.Name);
                Console.WriteLine(output);
            }
        }
    }
}