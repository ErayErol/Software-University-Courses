using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
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

            string operation;
            
            while ((operation = Console.ReadLine()) != "end")
            {
                string[] operationArr = operation
                .Split()
                .ToArray();

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
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
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
    }
}
