using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            var VIP = new HashSet<string>();
            var regular = new HashSet<string>();

            while (true)
            {
                var commands = Console.ReadLine();
                if (commands == "PARTY")
                {
                    while (true)
                    {
                        commands = Console.ReadLine();
                        if (commands == "END")
                        {
                            var sum = VIP.Count + regular.Count;
                            Console.WriteLine(sum);

                            if (VIP.Count > 0)
                            {
                                Console.WriteLine(string.Join("\r\n", VIP));
                            }
                            Console.WriteLine(string.Join("\r\n", regular));
                            return;
                        }

                        VIP.Remove(commands);
                        regular.Remove(commands);
                    }
                }
                else if (commands.Length == 8 && char.IsDigit(commands[0]))
                {
                    VIP.Add(commands);
                }
                else if (commands.Length == 8)
                {
                    regular.Add(commands);
                }
            }
        }
    }
}