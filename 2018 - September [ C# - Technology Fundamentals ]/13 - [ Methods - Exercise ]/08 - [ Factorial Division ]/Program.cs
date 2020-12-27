using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine($"{NumbersFactorial(firstNumber, secondNumber):f2}");
        }

        static double NumbersFactorial(int firstNumber, int secondNumber)
        {
            double firstNumberFactorial = 1;
            double secondNumberFactorial = 1;

            for (int i = 1; i <= firstNumber; i++)
            {
                firstNumberFactorial *= i;
            }

            for (int i = 1; i <= secondNumber; i++)
            {
                secondNumberFactorial *= i;
            }

            double result = FactorialDivision(firstNumberFactorial, secondNumberFactorial);

            return result;
        }

        static double FactorialDivision(double firstNumberFactorial, double secondNumberFactorial)
        {
            double division = firstNumberFactorial / secondNumberFactorial;
            return division;
        }
    }
}
