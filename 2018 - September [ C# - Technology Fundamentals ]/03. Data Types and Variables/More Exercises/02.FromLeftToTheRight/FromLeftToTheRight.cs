namespace _02.FromLeftToTheRight
{
    using System;

    class FromLeftToTheRight
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            long number = 0;

            for (int i = 0; i < count; i++)
            {
                string[] numbers = Console.ReadLine().Split();

                long firstNumber = long.Parse(numbers[0]);
                long secondNumber = long.Parse(numbers[1]);

                if (firstNumber > secondNumber)
                {
                    number = firstNumber;
                    PrintSum(number);
                }
                else
                {
                    number = secondNumber;
                    PrintSum(number);
                }
            }
        }

        static void PrintSum(long number)
        {
            long sum = 0;

            while (number != 0)
            {
                long currentNumber = number % 10;
                sum += currentNumber;
                number = number / 10;
            }

            Console.WriteLine(Math.Abs(sum));
        }
    }
}