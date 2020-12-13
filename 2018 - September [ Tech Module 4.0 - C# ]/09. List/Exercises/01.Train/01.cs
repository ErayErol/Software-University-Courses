using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();

            int maxCapacityOfEachWagons = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                if (commands[0] == "Add")
                {
                    wagons.Add(int.Parse(commands[1]));
                }
                else
                {
                    int num = int.Parse(commands[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (num + wagons[i] > maxCapacityOfEachWagons)
                        {
                            continue;
                        }
                        else
                        {
                            wagons[i] += num;
                            break;
                        }
                    }
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
