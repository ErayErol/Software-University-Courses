using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1; num <= n; num++)
            {
                int lastDigit = num % 10;
                int middleDigit = (num / 10) % 10;
                int firstDigit = middleDigit / 10;

                int sumOfDigit = lastDigit + middleDigit + firstDigit;
                if (sumOfDigit == 5 ||
                    sumOfDigit == 7 ||
                    sumOfDigit == 11)
                {
                    Console.WriteLine($"{num} -> True");
                }
                else
                {
                    Console.WriteLine($"{num} -> False");
                }
            }
        }
    }
}
