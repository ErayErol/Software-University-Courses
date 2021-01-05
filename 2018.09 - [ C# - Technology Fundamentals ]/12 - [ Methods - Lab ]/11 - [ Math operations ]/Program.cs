using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(MathOperations(firstNumber, operation, secondNumber));
        }

        static double MathOperations(double firstNumber, char operation, double secondNumber)
        {
            double result = 0;

            if (operation == '/')
            {
                result = firstNumber / secondNumber;
            }
            else if (operation == '*')
            {
                result = firstNumber * secondNumber;
            }
            else if (operation == '+')
            {
                result = firstNumber + secondNumber;
            }
            else if (operation == '-')
            {
                result = firstNumber - secondNumber;
            }

            return result;
        }
    }
}
