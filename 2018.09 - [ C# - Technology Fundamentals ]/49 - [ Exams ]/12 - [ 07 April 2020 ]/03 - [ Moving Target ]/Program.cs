using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "Shoot":
                        int shootIndex = int.Parse(commands[1]);
                        int shootPower = int.Parse(commands[2]);

                        if (shootIndex >= 0 && shootIndex < targets.Count)
                        {
                            Shooting(targets, shootIndex, shootPower);
                        }

                        break;
                    case "Add":
                        int addIndex = int.Parse(commands[1]);
                        int addValue = int.Parse(commands[2]);

                        if (addIndex >= 0 && addIndex < targets.Count)
                        {
                            Adding(targets, addIndex, addValue);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;
                    case "Strike":
                        int strikeIndex = int.Parse(commands[1]);
                        int strikeRadius = int.Parse(commands[2]);

                        if (strikeIndex >= 0 && strikeIndex < targets.Count)
                        {
                            Striking(targets, strikeIndex, strikeRadius);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join("|", targets));
        }

        static void Shooting(List<int> targets, int shootIndex, int shootPower)
        {
            targets[shootIndex] -= shootPower;
            
            if (targets[shootIndex] <= 0)
            {
                targets.RemoveAt(shootIndex);
            }
        }

        static void Adding(List<int> targets, int addIndex, int addValue)
        {
            targets.Insert(addIndex, addValue);
        }

        static void Striking(List<int> targets, int strikeIndex, int strikeRadius)
        {
            int left = strikeIndex - strikeRadius;
            int right = strikeIndex + strikeRadius;

            if (left >= 0 && right < targets.Count)
            {
                targets.RemoveRange(left, right - left + 1);
            }
            else
            {
                Console.WriteLine("Strike missed!");
            }
        }
    }
}
