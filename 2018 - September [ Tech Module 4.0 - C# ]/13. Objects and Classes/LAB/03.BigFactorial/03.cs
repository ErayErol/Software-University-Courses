using System;
using System.Numerics;

namespace _03.Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());

            BigInteger factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }
    }
}