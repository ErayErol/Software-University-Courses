using System;
using System.Linq;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] leftArray = new int[array.Length / 4];
            int[] rightArray = new int[array.Length / 4];

            for (int i = 0; i < leftArray.Length; i++)
            {
                leftArray[i] = array[array.Length / 4 - i - 1];
                rightArray[i] = array[array.Length - i - 1];
            }

            int[] sumArray = new int[array.Length / 2];

            for (int i = 0; i < leftArray.Length; i++)
            {
                sumArray[i] = leftArray[i] + array[array.Length / 4 + i];
                sumArray[array.Length / 4 + i] = rightArray[i] + array[array.Length / 2 + i];
            }

            foreach (int values in sumArray)
            {
                Console.Write($"{values} ");
            }
        }
    }
}
