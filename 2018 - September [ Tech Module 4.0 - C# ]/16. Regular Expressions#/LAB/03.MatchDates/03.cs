using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"\b(?<day>\d{2}\b)(?<symbol>[-.\/])(?<month>[A-Z]{1}[a-z]{2})(?<symbol2>\2)(?<year>\d{4}\b)\b");

            string dates = Console.ReadLine();

            foreach (Match date in pattern.Matches(dates))
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}