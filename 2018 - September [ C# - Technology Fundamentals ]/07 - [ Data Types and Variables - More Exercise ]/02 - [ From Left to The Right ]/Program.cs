using System;
using System.Linq;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLinesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLinesCount; i++)
            {
                string number = Console.ReadLine();
                string[] splittedNumbers = number.Split(' ');

                long leftNumber = long.Parse(splittedNumbers[0]);
                long rightNumber = long.Parse(splittedNumbers[1]);

                long biggestValue = leftNumber;
                if (rightNumber > leftNumber)
                {
                    biggestValue = rightNumber;
                }

                long digitsSum = 0;
                while (biggestValue != 0)
                {
                    digitsSum += biggestValue % 10;
                    biggestValue /= 10;
                }
                Console.WriteLine($"{Math.Abs(digitsSum)}");
            }
        }
    }
}
