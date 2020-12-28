using System;
using System.Collections.Generic;
using System.Linq;

namespace ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShipStatus = Console
                .ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();

            List<int> warShipStatus = Console
                .ReadLine()
                .Split(">")
                .Select(int.Parse)
                .ToList();

            int maximumHealth = int.Parse(Console.ReadLine());

            bool isShipSunken = false;

            string input;
           
            while ((input = Console.ReadLine()) != "Retire")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "Fire":
                        int firingIndex = int.Parse(commands[1]);
                        int firingDamage = int.Parse(commands[2]);

                        Firing(warShipStatus, firingIndex, firingDamage);

                        if (firingIndex >= 0 && firingIndex < warShipStatus.Count)
                        {
                            if (warShipStatus[firingIndex] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                isShipSunken = true;
                            }
                        }
                        break;
                    case "Defend":
                        int startingIndex = int.Parse(commands[1]);
                        int endingIndex = int.Parse(commands[2]);
                        int damage = int.Parse(commands[3]);

                        if ((startingIndex >= 0 && startingIndex < pirateShipStatus.Count) &&
                            (endingIndex >= 0 && endingIndex < pirateShipStatus.Count))
                        {
                            for (int i = startingIndex; i <= endingIndex; i++)
                            {
                                pirateShipStatus[i] -= damage;

                                if (pirateShipStatus[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    isShipSunken = true;
                                    
                                    break;
                                }
                            }
                        }
                        break;
                    case "Repair":
                        int repairingIndex = int.Parse(commands[1]);
                        int repairingHealth = int.Parse(commands[2]);

                        Repairing(pirateShipStatus, repairingIndex, repairingHealth, maximumHealth);
                        break;
                    case "Status":
                        int needsRepairingCount = Status(pirateShipStatus, maximumHealth);

                        Console.WriteLine($"{needsRepairingCount} sections need repair.");
                        break;
                }

                if (isShipSunken)
                {
                    break;
                }
            }

            if (!isShipSunken)
            {
                double pirateShipSum = pirateShipStatus.Sum();
                double warShipSum = warShipStatus.Sum();

                Console.WriteLine($"Pirate ship status: {pirateShipSum}");
                Console.WriteLine($"Warship status: {warShipSum}");
            }
        }

        static void Firing(List<int> warShipStatus, int firingIndex, int firingDamage)
        {
            if (firingIndex >= 0 && firingIndex < warShipStatus.Count)
            {
                warShipStatus[firingIndex] -= firingDamage;
            }
        }

        static void Repairing(List<int> pirateShipStatus, int repairingIndex, int repairingHealth, int maximumHealth)
        {
            if (repairingIndex >= 0 && repairingIndex < pirateShipStatus.Count)
            {
                pirateShipStatus[repairingIndex] += repairingHealth;

                if (pirateShipStatus[repairingIndex] > maximumHealth)
                {
                    pirateShipStatus[repairingIndex] = maximumHealth;
                }
            }
        }

        static int Status(List<int> pirateShipStatus, int maximumHealth)
        {
            double checkingHealth = maximumHealth * 0.20;
            
            int counter = 0;

            for (int i = 0; i < pirateShipStatus.Count; i++)
            {
                if (pirateShipStatus[i] < checkingHealth)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
