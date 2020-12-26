using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, string>();

            string name = @"@(?<name>\w+)\|";
            string age = @"#(?<age>\d+)\*";

            for (int i = 0; i < linesCount; i++)
            {
                string input = Console.ReadLine();

                var nameMatch = Regex.Match(input, name);
                var ageMatch = Regex.Match(input, age);

                dict.Add(nameMatch.Groups["name"].Value, ageMatch.Groups["age"].Value);
            }

            Console.WriteLine(string.Join(Environment.NewLine, dict
                .Select(x => $"{x.Key} is {x.Value} years old.")));
        }
    }
}
