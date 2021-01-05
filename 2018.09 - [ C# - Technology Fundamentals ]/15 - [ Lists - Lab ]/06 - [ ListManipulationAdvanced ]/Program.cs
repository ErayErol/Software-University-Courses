using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.
                ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool isOriginalListChanged = false;

            string operation;
            while ((operation = Console.ReadLine()) != "end")
            {
                string[] operationArr = operation
                .Split()
                .ToArray();

                if (operationArr[0] == "Add" ||
                    operationArr[0] == "Remove" ||
                    operationArr[0] == "RemoveAt" ||
                    operationArr[0] == "Insert")
                {
                    isOriginalListChanged = true;
                }

                switch (operationArr[0])
                {
                    case "Add":
                        Adding(numbers, int.Parse(operationArr[1]));
                        break;
                    case "Remove":
                        Removing(numbers, int.Parse(operationArr[1]));
                        break;
                    case "RemoveAt":
                        RemovingAt(numbers, int.Parse(operationArr[1]));
                        break;
                    case "Insert":
                        Inserting(numbers, int.Parse(operationArr[2]), int.Parse(operationArr[1]));
                        break;
                    case "Contains":
                        Contains(numbers, int.Parse(operationArr[1]));
                        break;
                    case "PrintEven":
                        PrintEven(numbers);
                        break;
                    case "PrintOdd":
                        PrintOdd(numbers);
                        break;
                    case "GetSum":
                        GetSum(numbers);
                        break;
                    case "Filter":
                        Filter(numbers, operationArr[1], int.Parse(operationArr[2]));
                        break;
                }
            }

            if (isOriginalListChanged)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        static void Adding(List<int> numbers, int number)
        {
            numbers.Add(number);
        }

        static void Removing(List<int> numbers, int number)
        {
            numbers.Remove(number);
        }

        static void RemovingAt(List<int> numbers, int index)
        {
            numbers.RemoveAt(index);
        }

        static void Inserting(List<int> numbers, int number, int index)
        {
            numbers.Insert(number, index);
        }

        static void Contains(List<int> numbers, int number)
        {
            if (numbers.Contains(number))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        static void PrintEven(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }

            Console.WriteLine();
        }

        static void PrintOdd(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }

            Console.WriteLine();
        }

        static void GetSum(List<int> numbers)
        {
            Console.WriteLine(numbers.Sum());
        }

        static void Filter(List<int> numbers, string condition, int number)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (condition == "<")
                {
                    if (numbers[i] < number)
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
                else if (condition == ">")
                {
                    if (numbers[i] > number)
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
                else if (condition == ">=")
                {
                    if (numbers[i] >= number)
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
                else if (condition == "<=")
                {
                    if (numbers[i] <= number)
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
