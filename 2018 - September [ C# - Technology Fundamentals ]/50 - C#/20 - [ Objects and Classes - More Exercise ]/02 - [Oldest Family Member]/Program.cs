using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int membersCount = int.Parse(Console.ReadLine());

            var peopleList = new List<Person>();

            for (int i = 0; i < membersCount; i++)
            {
                var memberInput = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                AddingMembers(peopleList, memberInput);
            }

            foreach (var item in peopleList.OrderByDescending(x => x.Age))
            {
                Console.WriteLine($"{item.Name} {item.Age}");
                break;
            }
        }

        public static void AddingMembers(List<Person> peopleList, List<string> memberInput)
        {
            string memberName = memberInput[0];
            int memberAge = int.Parse(memberInput[1]);

            Person person = new Person(memberName, memberAge);
            peopleList.Add(person);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
