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

            if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
            {
                type = "zero";
            }
            else if ((firstNumber > 0 && secondNumber > 0 && thirdNumber > 0) ||
                     (firstNumber < 0 && secondNumber < 0 && thirdNumber > 0) ||
                     (firstNumber < 0 && secondNumber > 0 && thirdNumber < 0) ||
                     (firstNumber > 0 && secondNumber < 0 && thirdNumber < 0))
            {
                type = "positive";
            }
            else
            {
                type = "negative";
            }

            return type;
        }

    }
}
