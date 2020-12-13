using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = double.Parse(Console.ReadLine());
            var second = double.Parse(Console.ReadLine());
            double factorial = 1;

            GetFactorial(first, second, factorial);
        }

        private static void GetFactorial(double first, double second, double factorial)
        {
            first = FirstNumberFactorial(first, factorial);
            second = SecondNumberFactorial(second, factorial);

            double factorialDivide = first / second;
            Console.WriteLine($"{factorialDivide:F2}");
        }

        static double SecondNumberFactorial(double second, double factorial)
        {
            for (double i = 1; i <= second; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }

        static double FirstNumberFactorial(double first, double factorial)
        {
            for (double i = 1; i <= first; i++)
            {
                factorial = factorial * i;
            }
            return factorial;
        }
    }
}
