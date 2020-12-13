using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = GetMultipleOfEvensAndOdds(n);
            Console.WriteLine(Math.Abs(sum));
        }

        static int GetSumOfOddDigits(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 != 0)
                {
                    sum += lastDigit;
                }

                n /= 10;
            }

            return sum;
        }

        static int GetSumOfEvenDigits(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 == 0)
                {
                    sum += lastDigit;
                }

                n /= 10;
            }

            return sum;
        }

        static int GetMultipleOfEvensAndOdds(int n)
        {
            int sumEvens = GetSumOfOddDigits(Math.Abs(n));
            int sumOdds = GetSumOfEvenDigits(Math.Abs(n));
            return sumEvens * sumOdds;
        }
    }
}
