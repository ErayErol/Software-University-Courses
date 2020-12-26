using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int i = 0; i < commandsCount; i++)
            {
                string input = Console.ReadLine();

                string[] command = input
                    .Split()
                    .ToArray();

                if (command[2] == "going!")
                {
                    if (ExistingPerson(command[0], guests))
                    {
                        guests.Add(command[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{command[0]} is already in the list!");
                    }
                }
                else if (command[2] == "not" && command[3] == "going!")
                {
                    if (!ExistingPerson(command[0], guests))
                    {
                        guests.Remove(command[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{command[0]} is not in the list!");
                    }
                }
            }

            PrintingAllGuests(guests);
        }

        static bool ExistingPerson(string name, List<string> guests)
        {
            if (!guests.Contains(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void PrintingAllGuests(List<string> guests)
        {
            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);
            }
        }
    }
}
