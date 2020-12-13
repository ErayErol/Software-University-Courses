namespace _02.KnightsОfHonor
{
    using System;
    using System.Linq;

    class KnightsОfHonor
    {
        static void Main(string[] args)
        {
            Action<string> print = Console.WriteLine;

            Console.ReadLine()
                .Split()
                .Select(x => $"Sir: {x}")
                .ToList()
                .ForEach(print);
        }
    }
}