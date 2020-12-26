using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            long[] arr = new long[counter];

            if (counter <= 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                arr[0] = 1;
                arr[1] = 1;

                for (int i = 2; i <= arr.Length - 1; i++)
                {
                    arr[i] = arr[i - 1] + arr[i - 2];
                }

                Console.WriteLine(arr[arr.Length - 1]);
            }

        }
    }
}
