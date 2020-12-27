using System;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(\+359 2 (\d{3} \d{4}\b))|(\+359-2-(\d{3}-\d{4}\b))";

            string phones = Console.ReadLine();

            MatchCollection matches = Regex.Matches(phones, regex);

            Console.Write(string.Join(", ", matches));
        }
    }
}
