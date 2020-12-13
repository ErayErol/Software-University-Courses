using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();

            string patternStar = @"[SsTtAaRr]";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int key = 0;
                string text = Console.ReadLine();

                MatchCollection regexDecrypt = Regex.Matches(text, patternStar);
                foreach (Match match in regexDecrypt)
                {
                    key++;
                }

                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < text.Length; j++)
                {
                    int currentIndex = text[j] - key;
                    sb.Append((char)currentIndex);
                }

                string textAfterDecrypt = sb.ToString();

                string pattern = @"[^@\-:!>]*@(?<name>[A-Za-z]+)[^@\-:!>]*:(?<population>[0-9]+)[^@\-:!>]*!(?<type>(A|D))![^@\-:!>]*->(?<count>[0-9]+)";
                MatchCollection regex = Regex.Matches(textAfterDecrypt, pattern);
                foreach (Match match in regex)
                {
                    if (match.Groups["type"].Value == "A")
                    {
                        attacked.Add(match.Groups["name"].Value);
                    }
                    else if (match.Groups["type"].Value == "D")
                    {
                        destroyed.Add(match.Groups["name"].Value);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (var name in attacked.OrderBy(a => a))
            {
                Console.WriteLine($"-> {name}");
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (var name in destroyed.OrderBy(a => a))
            {
                Console.WriteLine($"-> {name}");
            }
        }
    }
}