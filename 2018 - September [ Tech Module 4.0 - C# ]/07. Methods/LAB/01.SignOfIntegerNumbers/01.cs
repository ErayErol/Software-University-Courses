using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = double.Parse(Console.ReadLine());

            PrintSign(input);
        }

        private static void PrintSign(double input)
        {
            if (input > 0)
            {
                Console.WriteLine($"The number {input} is positive.");
            }
            else if (input < 0)
            {
                Console.WriteLine($"The number {input} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {input} is zero.");
            }
        }
    }
}
