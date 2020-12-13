using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger first = BigInteger.Parse(Console.ReadLine());
            BigInteger second = BigInteger.Parse(Console.ReadLine());
            BigInteger third = BigInteger.Parse(Console.ReadLine());

            GetSmallestNumber(first, second, third);
        }

        private static void GetSmallestNumber(BigInteger first, BigInteger second, BigInteger third)
        {
            if (first < second && first < third)
            {
                Console.WriteLine(first);
            }
            else if (second < first && second < third)
            {
                Console.WriteLine(second);
            }
            else if (third < first && third < second)
            {
                Console.WriteLine(third);
            }
            else
            {
                Console.WriteLine(first);
            }
        }
    }
}