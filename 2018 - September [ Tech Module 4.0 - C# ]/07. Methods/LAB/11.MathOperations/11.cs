using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var number0 = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            var number1 = double.Parse(Console.ReadLine());

            CalculateNumbers(number0, command, number1);
        }

        private static void CalculateNumbers(double number0, string command, double number1)
        {
            double result = 0.0;
            switch (command)
            {
                case "+": result = number0 + number1; break;
                case "*": result = number0 * number1; break;
                case "-": result = number0 - number1; break;
                case "/": result = number0 / number1; break;
            }

            Console.WriteLine(result);
        }
    }
}