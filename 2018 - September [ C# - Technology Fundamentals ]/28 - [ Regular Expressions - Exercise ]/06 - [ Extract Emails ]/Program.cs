using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))";

            string input = Console.ReadLine();

            MatchCollection matching = Regex.Matches(input, regex);

            foreach (var item in matching)
            {
                Console.WriteLine(item);
            }
        }
    }
}
