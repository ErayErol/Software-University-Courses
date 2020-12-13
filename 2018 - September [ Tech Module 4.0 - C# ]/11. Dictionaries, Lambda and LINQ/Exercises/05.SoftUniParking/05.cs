using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCommand = int.Parse(Console.ReadLine());

            var result = new Dictionary<string, string>();

            for (int i = 0; i < numberCommand; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string command = tokens[0];

                switch (command)
                {
                    case "register":
                        string userName = tokens[1];
                        string licenseNumber = tokens[2];

                        if (!result.ContainsKey(userName))
                        {
                            result.Add(userName, licenseNumber);
                            Console.WriteLine($"{userName} registered {licenseNumber} successfully");
                        }
                        else if (result.ContainsKey(userName))
                        {
                            Console.WriteLine("ERROR: already registered with plate number {0}", result[userName]);
                        }

                        break;

                    case "unregister":
                        userName = tokens[1];

                        if (!result.ContainsKey(userName))
                        {
                            Console.WriteLine($"ERROR: user {userName} not found");
                        }
                        else
                        {
                            result = result.Where(x => x.Key != userName).ToDictionary(k => k.Key, v => v.Value); // презаписване на резултата където ключът е различен от подаденият userName
                            Console.WriteLine($"{userName} unregistered successfully");
                        }

                        break;
                }
            }

            foreach (var user in result)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}