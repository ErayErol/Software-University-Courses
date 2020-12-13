using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            while (true)
            {
                var data = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "End")
                {
                    string find = Console.ReadLine();

                    Console.WriteLine(people.FirstOrDefault(x => x.Name == find).Name);
                    Console.WriteLine("Company: " + people.FirstOrDefault(x => x.Name == find).Company.ToString());
                    Console.WriteLine("Car: " + people.FirstOrDefault(x => x.Name == find).Car.ToString());
                    Console.WriteLine("Pokemon: " + string.Join("", people.FirstOrDefault(x => x.Name == find).Pokemons));
                    Console.WriteLine("Parents: " + string.Join("", people.FirstOrDefault(x => x.Name == find).Parents));
                    Console.WriteLine("Children: " + string.Join("", people.FirstOrDefault(x => x.Name == find).Children));

                    return;
                }

                string name = data[0];
                string kind = data[1];
                Person person = new Person(name);
                people.Add(person);

                switch (kind)
                {
                    case "company":
                        string companyName = data[2];
                        string department = data[3];
                        string salary = data[4];
                        Company company = new Company(companyName, department, salary);
                        people.FirstOrDefault(x => x.Name == name).Company = company;
                        break;
                    case "pokemon":
                        string pokemonName = data[2];
                        string pokemonType = data[3];
                        Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                        people.FirstOrDefault(x => x.Name == name).Pokemons.Add(pokemon);
                        break;
                    case "parents":
                        string parentName = data[2];
                        string parentBirthday = data[3];
                        Parent parent = new Parent(parentName, parentBirthday);
                        people.FirstOrDefault(x => x.Name == name).Parents.Add(parent);
                        break;
                    case "children":
                        string childName = data[2];
                        string childBirthday = data[3];
                        Children child = new Children(childName, childBirthday);
                        people.FirstOrDefault(x => x.Name == name).Children.Add(child);
                        break;
                    case "car":
                        string carModel = data[2];
                        string carSpeed = data[3];
                        Car car = new Car(carModel, carSpeed);
                        person.Car = car;
                        people.FirstOrDefault(x => x.Name == name).Car = car;
                        break;
                }
            }
        }
    }
}