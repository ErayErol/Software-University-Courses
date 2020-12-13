using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            //string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            //string names = Console.ReadLine();

            //MatchCollection matchedNames = Regex.Matches(names, regex);

            //foreach (Match name in matchedNames)
            //{
            //    Console.Write(name.Value + " ");
            //}

            //Console.WriteLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            string input = Console.ReadLine();

            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.Write($"{m} ");
            }

            Console.WriteLine();
        }
    }
}