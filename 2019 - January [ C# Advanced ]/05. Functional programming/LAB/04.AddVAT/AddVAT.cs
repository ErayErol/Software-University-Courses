namespace _04.AddVAT
{
    using System;
    using System.Linq;

    class AddVAT
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(n => n * 1.2m)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:F2}"));
        }
    }
}