using System;
using System.Collections.Generic;
using System.Linq;

namespace Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> weaponName = Console
                .ReadLine()
                .Split("|")
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "Move":
                        int index = int.Parse(commands[2]);

                        switch (commands[1])
                        {
                            case "Left":
                                MovingLeft(weaponName, index);
                                break;
                            case "Right":
                                MovingRight(weaponName, index);
                                break;
                        }
                        break;
                    case "Check":
                        switch (commands[1])
                        {
                            case "Even":
                                CheckingEven(weaponName);
                                
                                Console.WriteLine();
                                break;
                            case "Odd":
                                CheckingOdd(weaponName);
                                
                                Console.WriteLine();
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine($"You crafted {string.Join("", weaponName)}!");
        }

        static void MovingLeft(List<string> weaponName, int index)
        {
            if (index >= 1 && index < weaponName.Count)
            {
                string firstTemp = weaponName[index];
                string secondTemp = weaponName[index - 1];

                weaponName[index] = secondTemp;
                weaponName[index - 1] = firstTemp;
            }
        }

        static void MovingRight(List<string> weaponName, int index)
        {
            if (index >= 0 && index < weaponName.Count - 1)
            {
                string firstTemp = weaponName[index];
                string secondTemp = weaponName[index + 1];

                weaponName[index] = secondTemp;
                weaponName[index + 1] = firstTemp;
            }
        }

        static void CheckingEven(List<string> weaponName)
        {
            for (int i = 0; i < weaponName.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(weaponName[i] + " ");
                }
            }
        }

        static void CheckingOdd(List<string> weaponName)
        {
            for (int i = 0; i < weaponName.Count; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write(weaponName[i] + " ");
                }
            }
        }
    }
}
