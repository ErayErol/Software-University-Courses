using System;
using System.Collections.Generic;
using System.Linq;

namespace midExamSundayFundamentalsArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;
            int firstIndex = 0;
            int secondIndex = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "swap":
                        firstIndex = int.Parse(commands[1]);
                        secondIndex = int.Parse(commands[2]);

                        SwappingNumbers(listNumbers, firstIndex, secondIndex);
                        break;
                    case "multiply":
                        firstIndex = int.Parse(commands[1]);
                        secondIndex = int.Parse(commands[2]);

                        MultiplyingNumbers(listNumbers, firstIndex, secondIndex);
                        break;
                    case "decrease":
                        DecreasingNumbers(listNumbers);
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", listNumbers));
        }

        static void SwappingNumbers(List<int> listNumbers, int firstIndex, int secondIndex)
        {
            int temp = listNumbers[firstIndex];
            listNumbers[firstIndex] = listNumbers[secondIndex];
            listNumbers[secondIndex] = temp;
        }

        static void MultiplyingNumbers(List<int> listNumbers, int firstIndex, int secondIndex)
        {
            listNumbers[firstIndex] = listNumbers[firstIndex] * listNumbers[secondIndex];
        }

        static void DecreasingNumbers(List<int> listNumbers)
        {
            for (int i = 0; i < listNumbers.Count; i++)
            {
                listNumbers[i]--;
            }
        }
    }
}
