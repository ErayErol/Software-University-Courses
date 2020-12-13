using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            var input0 = decimal.Parse(Console.ReadLine());
            var input1 = decimal.Parse(Console.ReadLine());

            var result = GetMathPow(input0, input1);
            Console.WriteLine(result);
        }

        static decimal GetMathPow(decimal input0, decimal input1)
        {
            decimal result = input0;
            for (decimal i = 1; i < input1; i++)
            {
                result = result * input0;
            }

            return result;
        }
    }
}