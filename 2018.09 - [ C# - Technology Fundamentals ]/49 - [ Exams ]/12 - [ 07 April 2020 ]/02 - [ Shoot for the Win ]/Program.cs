using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;
            List<int> indexes = new List<int>();

            int shotsCounter = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                int index = int.Parse(input);
                if (index >= 0 && index <= numbers.Count - 1)
                {
                    int currNumber = numbers[index];

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] != -1 && i != index)
                        {
                            if (numbers[i] > currNumber)
                            {
                                numbers[i] -= currNumber;
                            }
                            else
                            {
                                numbers[i] += currNumber;
                            }
                        }

                        numbers[index] = -1;
                    }

                    shotsCounter++;
                }
            }

            Console.WriteLine($"Shot targets: {shotsCounter} -> {string.Join(" ", numbers)}");
        }
    }
}
