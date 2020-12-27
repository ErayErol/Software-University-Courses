using System;

namespace SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int n = 1;
            for (int i = 1; i <= number; i++)
            {
                sum += n;
                Console.WriteLine(n);
                n += 2;
            }
            
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
