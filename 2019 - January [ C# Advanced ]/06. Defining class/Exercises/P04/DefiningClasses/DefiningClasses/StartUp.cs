namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string name = commands[0];
                int age = int.Parse(commands[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            List<Person> peopleOverThirty = family.GetPeopleOverThierty().OrderBy(p => p.Name).ToList();
            Console.WriteLine(string.Join("\n", peopleOverThirty));
        }
    }
}