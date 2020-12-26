using System;

namespace SignOfIntegerNumbers2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            SignOfInteger(number);
        }

        static void SignOfInteger(int number)
        {
            int result = number.CompareTo(0);
            if (result > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (result < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else
            {
                Console.WriteLine($"The number {number} is zero.");
            }
        }
    }
}
