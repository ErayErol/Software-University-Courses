using System;

namespace TribonacciSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            TribonacciSequenceCalculations(counter);
        }

        static void TribonacciSequenceCalculations(int counter)
        {
            if (counter > 2)
            {
                long[] arr = new long[counter];

                arr[0] = 1;
                arr[1] = 1;
                arr[2] = 2;

                for (int i = 3; i < counter; i++)
                {
                    arr[i] = arr[i - 1] + arr[i - 2] + arr[i - 3];
                }

                foreach (var item in arr)
                {
                    Console.Write(item + " ");
                }
            }
            else
            {
                if (counter <= 0)
                {
                    Console.WriteLine(0);
                }
                else if (counter == 1)
                {
                    Console.WriteLine(1);

                }
                else if (counter == 2)
                {
                    Console.WriteLine(1 + " " + 1);
                }
            }
        }
    }
}
