using System;

namespace MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double thirdNumber = double.Parse(Console.ReadLine());

            string result = MultiplicationSign(firstNumber, secondNumber, thirdNumber);

            Console.WriteLine(result);
        }

        static string MultiplicationSign(double firstNumber, double secondNumber, double thirdNumber)
        {
            string type = string.Empty;

            double result = Multiplication(firstNumber, secondNumber, thirdNumber);

            if (result < 0)
            {
                type = "negative";
            }
            else if (result == 0)
            {
                type = "zero";
            }
            else if (result > 0)
            {
                type = "positive";
            }

            return type;
        }

        static double Multiplication(double firstNumber, double secondNumber, double thirdNumber)
        {
            double multiplication = firstNumber * secondNumber * thirdNumber;
            return multiplication;
        }
    }
}
