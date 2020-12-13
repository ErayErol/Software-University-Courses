using System;
using System.Text.RegularExpressions;

namespace _05.MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            string input = @"1 -1 1s 123 s-s -123 _55_ _f 123.456 -123.456 s-1.1 s2 -1- zs-2 s-3.5";

            Match m = Regex.Match(input, pattern);
            Console.WriteLine("'{0}' found at index {1}", m.Value, m.Index);
        }
    }
}