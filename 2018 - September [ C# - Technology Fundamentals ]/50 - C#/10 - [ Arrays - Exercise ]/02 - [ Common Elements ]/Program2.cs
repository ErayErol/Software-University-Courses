using System;
using System.Linq;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console
                .ReadLine()
                .Split();

            string[] secondArr = Console
                .ReadLine()
                .Split();

            for (int i = 0; i < secondArr.Length; i++)
            {
                if (firstArr.Contains(secondArr[i]))
                {
                    Console.Write($"{secondArr[i]} ");
                }
            }
        }
    }
}

