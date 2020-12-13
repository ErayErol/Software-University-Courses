namespace _06.EqualSum
{
    using System;
    using System.Linq;

    class EqualSum
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (numbers.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }

            int sumLeft = 0;
            int sumRight = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sumLeft = numbers.Take(i).Sum();

                sumRight = numbers.Skip(i + 1).Sum();

                if (sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}