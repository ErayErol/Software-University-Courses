using System;
using System.Collections.Generic;
using System.Linq;

namespace MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> rooms = Console
                .ReadLine()
                .Split("|")
                .ToList();

            int startingHealth = 100;
            int startingBitcoins = 0;

            int roomsCounter = 0;

            while (true)
            {
                string[] command = rooms[roomsCounter].Split(" ");

                switch (command[0])
                {
                    case "potion":
                        int healthFromPotion = int.Parse(command[1]);
                        int currHP = startingHealth;

                        startingHealth += healthFromPotion;

                        if (startingHealth > 100)
                        {
                            startingHealth = 100;
                            Console.WriteLine($"You healed for {100 - currHP} hp.");
                        }
                        else
                        {
                            Console.WriteLine($"You healed for {healthFromPotion} hp.");
                        }

                        Console.WriteLine($"Current health: {startingHealth} hp.");

                        break;
                    case "chest":
                        int bitcoinsFound = int.Parse(command[1]);
                        startingBitcoins += bitcoinsFound;

                        Console.WriteLine($"You found {bitcoinsFound} bitcoins.");

                        break;
                    default:
                        int damageTook = int.Parse(command[1]);

                        startingHealth -= damageTook;
                        if (startingHealth > 0)
                        {
                            Console.WriteLine($"You slayed {command[0]}.");
                        }

                        break;
                }

                roomsCounter++;

                if (startingHealth <= 0)
                {
                    Console.WriteLine($"You died! Killed by {command[0]}.");
                    Console.WriteLine($"Best room: {roomsCounter}");

                    break;
                }

                if (roomsCounter == rooms.Count)
                {
                    Console.WriteLine($"You've made it!");
                    Console.WriteLine($"Bitcoins: {startingBitcoins}");
                    Console.WriteLine($"Health: {startingHealth}");

                    break;
                }
            }
        }
    }
}
