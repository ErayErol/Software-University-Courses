using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> passengersInWagons = Console.
                ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            AddingPassengersAndWagons(passengersInWagons);
        }

        static void AddingPassengersAndWagons(List<int> passengersInWagons)
        {
            int maxCapacityOfEachWagon = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input
                    .Split()
                    .ToArray();

                if (command[0] == "Add")
                {
                    AddingWagons(int.Parse(command[1]), passengersInWagons);
                }
                else
                {
                    AddingPassengers(command[0], passengersInWagons, maxCapacityOfEachWagon);
                }
            }

            Console.WriteLine(string.Join(" ", passengersInWagons));
        }

        static void AddingWagons(int passengersInNewWagon, List<int> passengersInWagons)
        {
            passengersInWagons.Add(passengersInNewWagon);
        }

        static void AddingPassengers(string command, List<int> passengersInWagons, int maxCapacityOfEachWagon)
        {
            int passengersCount = int.Parse(command);

            for (int i = 0; i < passengersInWagons.Count; i++)
            {
                if (passengersInWagons[i] + passengersCount <= maxCapacityOfEachWagon)
                {
                    passengersInWagons[i] += passengersCount;
                    break;
                }
            }
        }
    }
}
