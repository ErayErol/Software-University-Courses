using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            if (arr.Length == 1)
            {
                Console.WriteLine(arr[0]);
            }
            else
            {
                int[] condensedArr = new int[arr.Length - 1];
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < condensedArr.Length - i; j++)
                    {
                        condensedArr[j] = arr[j] + arr[j + 1];
                    }
                    condensedArr = arr;
                }
                Console.WriteLine(condensedArr[0]);
            }
        }
    }
}
