using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ");
            var nameDistance = new Dictionary<string, int>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end of race")
                {
                    int index = 1;
                    foreach (var participants in nameDistance.OrderByDescending(p => p.Value))
                    {
                        if (index == 1)
                        {
                            Console.WriteLine($"1st place: {participants.Key}");
                        }
                        else if (index == 2)
                        {
                            Console.WriteLine($"2nd place: {participants.Key}");
                        }
                        else if (index == 3)
                        {
                            Console.WriteLine($"3rd place: {participants.Key}");
                        }

                        index++;
                        if (index == 4)
                        {
                            Environment.Exit(0);
                        }
                    }

                    break;
                }

                string pattern = @"[A-Za-z]+";
                MatchCollection regex = Regex.Matches(command, pattern);
                StringBuilder sb = new StringBuilder();
                foreach (Match match in regex)
                {
                    sb.Append(match);
                }

                string name = sb.ToString();
                int sum = 0;
                if (names.Contains(name))
                {
                    for (int i = 0; i < command.Length; i++)
                    {
                        if (char.IsDigit(command[i]))
                        {
                            sum += int.Parse(command[i].ToString());
                        }
                    }
                    if (nameDistance.ContainsKey(name) == false)
                    {
                        nameDistance.Add(name, 0);
                    }

                    nameDistance[name] += sum;
                }
            }
        }
    }
}