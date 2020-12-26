using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string personName = @"[A-Za-z]";
            string personKm = @"\d";

            var dict = new Dictionary<string, int>();

            List<string> racers = Console
                .ReadLine()
                .Split(", ")
                .ToList();

            while ((input = Console.ReadLine()) != "end of race")
            {
                var name = string.Concat(Regex.Matches(input, personName));
                var points = Regex.Matches(input, personKm);

                if (racers.Contains(name))
                {
                    if (!dict.ContainsKey(name))
                    {
                        dict[name] = 0;
                    }

                    dict[name] += points.Select(x => int.Parse(x.Value)).Sum();
                }
            }

            var sorted = dict
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .ToList();

            Console.WriteLine($"1st place: {sorted[0]}");
            Console.WriteLine($"2nd place: {sorted[1]}");
            Console.WriteLine($"3rd place: {sorted[2]}");
        }
    }
}
