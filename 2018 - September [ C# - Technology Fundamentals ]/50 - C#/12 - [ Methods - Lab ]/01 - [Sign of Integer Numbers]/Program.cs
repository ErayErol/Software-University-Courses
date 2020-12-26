using System;

namespace SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (SignOfNumber(number) == -1)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else if (SignOfNumber(number) == 0)
            {
                Console.WriteLine($"The number {number} is zero.");
            }
            else
            {
                Console.WriteLine($"The number {number} is positive.");
            }
        }

        static int SignOfNumber(int number)
        {
            if (number < 0)
            {
                return -1;
            }
            else if (number == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
