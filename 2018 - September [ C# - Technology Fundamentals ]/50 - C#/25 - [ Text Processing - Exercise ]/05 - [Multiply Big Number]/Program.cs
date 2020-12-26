using System;
using System.Numerics;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());

            BigInteger sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += number;

            }

            Console.WriteLine(sum);
        }
    }
}
