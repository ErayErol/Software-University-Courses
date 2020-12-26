using System;
using System.Collections.Generic;
using System.Linq;

namespace DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());

            List<int> drumSet = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> drumSetCopy = new List<int>();

            for (int i = 0; i < drumSet.Count; i++)
            {
                drumSetCopy.Add(drumSet[i]);
            }

            string command;
            
            while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(command);

                for (int i = 0; i < drumSetCopy.Count; i++)
                {
                    drumSetCopy[i] -= hitPower;
                    if (drumSetCopy[i] <= 0)
                    {
                        int price = drumSet[i] * 3;

                        if (savings >= price)
                        {
                            savings -= price;
                            drumSetCopy[i] = drumSet[i];
                        }
                    }
                }

                for (int i = 0; i < drumSetCopy.Count; i++)
                {
                    if (drumSetCopy[i] <= 0)
                    {
                        drumSet.Remove(drumSet[i]);
                        drumSetCopy.Remove(drumSetCopy[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", drumSetCopy));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
