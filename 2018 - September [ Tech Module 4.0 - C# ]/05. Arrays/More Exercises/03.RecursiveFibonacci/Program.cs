using System;
using System.Numerics;

namespace _03.RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Int32.Parse(Console.ReadLine());

            if (count == 1 || count == 2)
            {
                Console.WriteLine(1);
                Environment.Exit(0);
            }

            BigInteger first = 1;
            BigInteger last = 1;

            BigInteger fibonaci = 0;

            for (int i = 0; i < count - 2; i++)
            {
                fibonaci = first + last;
                first = last;
                last = fibonaci;
            }

            Console.WriteLine(fibonaci);
        }
    }
}