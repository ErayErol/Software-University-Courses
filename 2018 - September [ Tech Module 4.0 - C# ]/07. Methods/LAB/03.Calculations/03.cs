using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine().ToLower();
            var number0 = double.Parse(Console.ReadLine());
            var number1 = double.Parse(Console.ReadLine());

            CalculateNumbers(command, number0, number1);
        }

        private static void CalculateNumbers(string command, double number0, double number1)
        {
            double result = 0.0;
            switch (command)
            {
                case "add": result = number0 + number1; break;
                case "multiply": result = number0 * number1; break;
                case "subtract": result = number0 - number1; break;
                case "divide": result = number0 / number1; break;
            }

            Console.WriteLine(result);
        }
    }
}
