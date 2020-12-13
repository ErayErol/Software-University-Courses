namespace _01.ActionPoint
{
    using System;
    using System.Linq;

    class ActionPoint
    {
        static void Main(string[] args)
        {
            Action<string> print = Console.WriteLine;

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(print);

        }
    }
}