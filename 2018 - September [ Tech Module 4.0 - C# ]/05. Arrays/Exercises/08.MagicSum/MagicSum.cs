namespace _08.MagicSum
{
    using System;
    using System.Linq;

    class MagicSum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int magicSum = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int e = i + 1; e < numbers.Length; e++)
                {
                    sum = numbers[i] + numbers[e];
                    if (sum == magicSum)
                    {
                        Console.WriteLine(numbers[i] + " " + numbers[e]);
                    }
                }
            }
        }
    }
}