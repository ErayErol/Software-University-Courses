using System;
using System.Collections.Generic;

namespace _04.TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            PrintTribonacci(count);
        }

        static void PrintTribonacci(int count)
        {
            List<int> tribonacciSequance = new List<int>();

            int tribonacci = 1;

            int first = 1;
            int second = 1;
            int third = 2;

            if (count > 0)
            {
                tribonacciSequance.Add(first);
            }
            if (count > 1)
            {
                tribonacciSequance.Add(second);
            }
            if (count > 2)
            {
                tribonacciSequance.Add(third);
            }

            for (int i = 3; i < count; i++)
            {
                tribonacci = first + second + third;
                first = second;
                second = third;
                third = tribonacci;

                tribonacciSequance.Add(tribonacci);
            }

            Console.WriteLine(string.Join(" ", tribonacciSequance));
        }
    }
}