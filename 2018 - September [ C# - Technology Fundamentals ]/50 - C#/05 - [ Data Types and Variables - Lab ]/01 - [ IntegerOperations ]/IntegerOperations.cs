namespace _01.IntegerOperations
{
    using System;

    class IntegerOperations
    {
        static void Main(string[] args)
        {
            long first = long.Parse(Console.ReadLine());
            long second = long.Parse(Console.ReadLine());
            long third = long.Parse(Console.ReadLine());
            long fourth = long.Parse(Console.ReadLine());

            long sum = ((first + second) / third) * fourth;
            Console.WriteLine(sum);
        }
    }
}