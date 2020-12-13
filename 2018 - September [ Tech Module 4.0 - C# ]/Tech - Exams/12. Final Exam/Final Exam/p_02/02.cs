using System;
using System.Text;
using System.Text.RegularExpressions;

namespace p_02
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string pattern = @"^[A-Z][a-z]+( [a-z]+(')?( )?[a-z]+)*:[A-Z\s]+$";
                Match regex = Regex.Match(input, pattern);
                if (regex.Success)
                {
                    string[] splitted = input.Split(":");
                    string actor = splitted[0];

                    int key = actor.Length;

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < input.Length; i++)
                    {
                        char currentToken = input[i];

                        if (currentToken == ' ' || currentToken == '\'')
                        {
                            sb.Append(currentToken);
                            continue;
                        }

                        if (currentToken == ':')
                        {
                            sb.Append("@");
                            continue;
                        }

                        int index = currentToken + key;

                        if (char.IsUpper(currentToken))
                        {
                            if (index > 90)
                            {
                                index = index % 90;
                                int start = 64 + index;
                                sb.Append((char)start);
                            }
                            else
                            {
                                sb.Append((char)index);
                            }
                        }
                        else
                        {
                            if (index > 122)
                            {
                                index = index % 122;
                                int start = 96 + index;
                                sb.Append((char)start);
                            }
                            else
                            {
                                sb.Append((char)index);
                            }
                        }
                    }

                    Console.WriteLine($"Successful encryption: {sb}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}