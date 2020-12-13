using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            var list = new List<int> { num1, num2, num3 };

            if (list.Contains(0))
            {
                Console.WriteLine("zero");
                return;
            }
            else
            {
                PrintResult(list);
            }
        }

        static void PrintResult(List<int> list)
        {
            int countNegative = list.Where(x => x < 0).Count();

            if (countNegative == 0 || countNegative == 2)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }
        }
    }
}