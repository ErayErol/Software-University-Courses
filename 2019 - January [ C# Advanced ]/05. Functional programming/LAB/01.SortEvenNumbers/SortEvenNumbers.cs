namespace _01.SortEvenNumbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(',', ' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine(string.Join(", ", input.Where(x => x % 2 == 0).OrderBy(x => x)));
        }
    }
}