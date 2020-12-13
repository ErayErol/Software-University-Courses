using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintTriangle(num);
        }

        static void PrintTriangle(int num)
        {
            PrintTopPart(num);
            PrintBottonPart(num);
        }

        static void PrintTopPart(int num)
        {
            for (int row = 1; row <= num; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write(col + " ");
                }

                Console.WriteLine();
            }
        }

        static void PrintBottonPart(int num)
        {
            for (int row = num - 1; row >= 1; row--)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write(col + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
