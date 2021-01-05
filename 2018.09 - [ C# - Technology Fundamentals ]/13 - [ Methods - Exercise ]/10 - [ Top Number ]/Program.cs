using System;

namespace TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            CheckingForTopNumbers(number);
        }

        static void CheckingForTopNumbers(int number)
        {
            for (int i = 0; i <= number; i++)
            {
                int sum = 0;
                int currNumber = i;

                bool isDigitOdd = false;

                while (currNumber != 0)
                {
                    int digit = currNumber % 10;

                    if (digit % 2 != 0)
                    {
                        isDigitOdd = true;
                    }

                    sum += digit;
                    currNumber /= 10;
                }

                if (sum % 8 == 0 && isDigitOdd)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
