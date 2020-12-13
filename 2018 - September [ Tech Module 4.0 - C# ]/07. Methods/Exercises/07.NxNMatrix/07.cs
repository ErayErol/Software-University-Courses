using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = long.Parse(Console.ReadLine());

            GetNxNMatrix(input);
        }

        private static void GetNxNMatrix(long input)
        {
            for (int i = 0; i < input; i++)
            {
                Console.Write(input + " ");
                for (int j = 1; j < input; j++)
                {
                    Console.Write(input + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
