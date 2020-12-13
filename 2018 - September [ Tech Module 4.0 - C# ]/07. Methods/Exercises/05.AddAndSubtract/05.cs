using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            GetResult(first, second, third);
        }

        private static void GetResult(int first, int second, int third)
        {
            int sum = GetSum(first, second);
            int subtract = GetSubtract(sum, third);

            int result = subtract;
            Console.WriteLine(result);
        }

        private static int GetSubtract(int sum, int third)
        {
            return sum - third;
        }

        private static int GetSum(int first, int second)
        {
            return first + second;
        }
    }
}