using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberArray
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
            int index = 0;
            int value = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "Switch":
                        index = int.Parse(commands[1]);

                        SwitchingNumbers(numbers, index);
                        break;
                    case "Change":
                        index = int.Parse(commands[1]);
                        value = int.Parse(commands[2]);

                        ChangingNumbers(numbers, index, value);
                        break;
                    case "Sum":
                        switch (commands[1])
                        {
                            case "Negative":
                                Console.WriteLine(SummingNegativesNumbers(numbers));
                                break;
                            case "Positive":
                                Console.WriteLine(SummingPositivesNumbers(numbers));
                                break;
                            case "All":
                                Console.WriteLine(SummingAllNumbers(numbers));
                                break;
                        }
                        break;
                }
            }

            PrintingAllPositives(numbers);
        }

        static void SwitchingNumbers(List<int> numbers, int index)
        {
            if (index >= 0 && index < numbers.Count)
            {
                int value = numbers[index];

                numbers[index] = value - (2 * value);
            }
        }

        static void ChangingNumbers(List<int> numbers, int index, int value)
        {
            if (index >= 0 && index < numbers.Count)
            {
                numbers[index] = value;
            }
        }

        static int SummingNegativesNumbers(List<int> numbers)
        {
            int negativesSum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    negativesSum += numbers[i];
                }
            }

            return negativesSum;
        }

        static int SummingPositivesNumbers(List<int> numbers)
        {
            int positivesSum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= 0)
                {
                    positivesSum += numbers[i];
                }
            }

            return positivesSum;
        }

        static int SummingAllNumbers(List<int> numbers)
        {
            int allSum = numbers.Sum();

            return allSum;
        }

        static void PrintingAllPositives(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}
