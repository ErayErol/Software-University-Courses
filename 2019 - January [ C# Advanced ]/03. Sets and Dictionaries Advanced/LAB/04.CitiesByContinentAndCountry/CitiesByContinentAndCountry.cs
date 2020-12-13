using System;
using System.Collections.Generic;

namespace _04.CitiesByContinentAndCountry
{
    class CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Dictionary<string, List<string>>>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var continent = commands[0];
                var country = commands[1];
                var city = commands[2];

                if (dictionary.ContainsKey(continent) == false)
                {
                    dictionary.Add(continent, new Dictionary<string, List<string>>());
                    dictionary[continent].Add(country, new List<string>());
                }
                else if (dictionary[continent].ContainsKey(country) == false)
                {
                    dictionary[continent].Add(country, new List<string>());
                }
                dictionary[continent][country].Add(city);
            }

            foreach (var continent in dictionary)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var countryCity in continent.Value)
                {
                    Console.WriteLine($"  {countryCity.Key} -> {string.Join(", ", countryCity.Value)}");
                }
            }
        }
    }
}