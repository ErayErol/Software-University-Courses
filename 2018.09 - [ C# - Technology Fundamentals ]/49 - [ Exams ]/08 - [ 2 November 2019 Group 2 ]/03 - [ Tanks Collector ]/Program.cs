using System;
using System.Collections.Generic;
using System.Linq;

namespace TanksCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ownedTanks = Console
                .ReadLine()
                .Split(", ")
                .ToList();

            int collectingCounter = int.Parse(Console.ReadLine());
            string tankName = string.Empty;
            int index = 0;

            for (int i = 0; i < collectingCounter; i++)
            {
                string[] command = Console
                    .ReadLine()
                    .Split(", ")
                    .ToArray();

                switch (command[0])
                {
                    case "Add":
                        tankName = command[1];

                        AddingTank(ownedTanks, tankName);
                        break;
                    case "Remove":
                        tankName = command[1];

                        RemovingTank(ownedTanks, tankName);
                        break;
                    case "Remove At":
                        index = int.Parse(command[1]);

                        RemovingTankAtPosition(ownedTanks, index);
                        break;
                    case "Insert":
                        tankName = command[2];
                        index = int.Parse(command[1]);

                        InsertingTank(ownedTanks, index, tankName);
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", ownedTanks));
        }

        static void AddingTank(List<string> ownedTanks, string tankName)
        {
            if (ownedTanks.Contains(tankName))
            {
                Console.WriteLine("Tank is already bought");
            }
            else
            {
                Console.WriteLine("Tank successfully bought");
                ownedTanks.Add(tankName);
            }
        }

        static void RemovingTank(List<string> ownedTanks, string tankName)
        {
            if (ownedTanks.Contains(tankName))
            {
                Console.WriteLine("Tank successfully sold");
                ownedTanks.Remove(tankName);
            }
            else
            {
                Console.WriteLine("Tank not found");
            }
        }

        static void RemovingTankAtPosition(List<string> ownedTanks, int index)
        {
            if (index >= 0 && index < ownedTanks.Count)
            {
                Console.WriteLine("Tank successfully sold");
                ownedTanks.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Index out of range");
            }
        }

        static void InsertingTank(List<string> ownedTanks, int index, string tankName)
        {
            if ((index >= 0 && index < ownedTanks.Count) && (ownedTanks.Contains(tankName)))
            {
                Console.WriteLine("Tank is already bought");
            }
            else if ((index >= 0 && index < ownedTanks.Count) && (!ownedTanks.Contains(tankName)))
            {
                Console.WriteLine("Tank successfully bought");
                ownedTanks.Insert(index, tankName);
            }
            else
            {
                Console.WriteLine("Index out of range");
            }
        }
    }
}
