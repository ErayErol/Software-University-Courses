namespace _09.SumOfOddNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class SumOfOddNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var oddNumbers = new List<int>();
            for (int i = 1; i <= n * 2; i += 2)
            {
                Console.WriteLine(i);
                oddNumbers.Add(i);
            }

            Console.WriteLine($"Sum: {oddNumbers.Sum()}");
        }
    }
}