using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternLady = @"[^A-Za-z\-]+";
            string patternBoy = @"[A-Za-z]+-[A-Za-z]+";

            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            while (input.Length != 0)
            {
                sb.Clear();
                MatchCollection regexLady = Regex.Matches(input, patternLady);
                foreach (Match match in regexLady)
                {
                    Console.WriteLine(match);
                    int index = 0;
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == match.ToString().First())
                        {
                            break;
                        }

                        index++;
                    }
                    bool isValid = true;

                    for (int i = index + match.Length; i < input.Length; i++)
                    {
                        sb.Append(input[i]);
                        isValid = false;
                    }

                    if (isValid)
                    {
                        Environment.Exit(0);
                    }
                    input = sb.ToString();
                    break;
                }

                sb.Clear();
                MatchCollection regexBoy = Regex.Matches(input, patternBoy);
                foreach (Match match in regexBoy)
                {
                    Console.WriteLine(match);
                    int index = 0;
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == match.ToString().First())
                        {
                            break;
                        }

                        index++;
                    }
                    bool isValid = true;

                    for (int i = index + match.Length; i < input.Length; i++)
                    {
                        sb.Append(input[i]);
                        isValid = false;
                    }

                    if (isValid)
                    {
                        Environment.Exit(0);
                    }
                    input = sb.ToString();
                    break;
                }
            }
        }
    }
}