using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var petrolPumps = new Queue<int[]>();

            for (int i = 0; i < count; i++)
            {
                petrolPumps.Enqueue(Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            }

            int counter = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (var current in petrolPumps)
                {
                    int fuel = current[0];
                    int distance = current[1];

                    totalFuel += fuel - distance;

                    if (totalFuel < 0)
                    {
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        counter++;
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    Console.WriteLine(counter);
                    Environment.Exit(0);
                }
            }
        }
    }
}