using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, string>();

            for (int i = 0; i < commandsCount; i++)
            {
                List<string> commandsArgs = Console
                    .ReadLine()
                    .Split()
                    .ToList();

                string command = commandsArgs[0];
                string name = commandsArgs[1];

                switch (command)
                {
                    case "register":
                        string plateNumber = commandsArgs[2];

                        if (!dict.ContainsKey(name))
                        {
                            dict[name] = plateNumber;
                            Console.WriteLine($"{name} registered {plateNumber} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {plateNumber}");
                        }
                        break;
                    case "unregister":
                        if (!dict.ContainsKey(name))
                        {
                            Console.WriteLine($"ERROR: user {name} not found");
                        }
                        else
                        {
                            dict.Remove(name);
                            Console.WriteLine($"{name} unregistered successfully");
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine,
                dict.Select(x => $"{x.Key} => {x.Value}")));
        }
    }
}
