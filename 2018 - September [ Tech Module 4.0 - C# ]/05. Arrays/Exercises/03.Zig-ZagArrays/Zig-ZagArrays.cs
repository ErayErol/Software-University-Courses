namespace _03.Zig_ZagArrays
{
    using System;
    using System.Linq;

    class ZigZagArrays
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstResult = new int[n];
            int[] secondResult = new int[n];

            int index = 0;
            for (int i = 1; i <= n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    firstResult[index] = numbers[1];
                    secondResult[index] = numbers[0];
                }
                else
                {
                    firstResult[index] = numbers[0];
                    secondResult[index] = numbers[1];
                }

                index++;
            }

            Console.WriteLine(string.Join(" ", firstResult));
            Console.WriteLine(string.Join(" ", secondResult));
        }
    }
}