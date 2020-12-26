using System;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            Console.WriteLine(GetMultipleOfEvenAndOdds(number));
        }

        static int GetMultipleOfEvenAndOdds(int number)
        {
            return GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
        }

        static int GetSumOfEvenDigits(int number)
        {
            int evenSum = 0;
            
            while (number != 0)
            {
                int digit = number % 10;

                if (digit % 2 == 0)
                {
                    evenSum += digit;
                }

                number /= 10;
            }

            return evenSum;
        }
        
        static int GetSumOfOddDigits(int number)
        {
            int oddSum = 0;
            
            while (number != 0)
            {
                int digit = number % 10;

                if (digit % 2 != 0)
                {
                    oddSum += digit;
                }

                number /= 10;
            }

            return oddSum;
        }
    }
}
