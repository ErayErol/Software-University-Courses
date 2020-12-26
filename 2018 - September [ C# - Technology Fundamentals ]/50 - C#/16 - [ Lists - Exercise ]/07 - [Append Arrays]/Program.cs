using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.
                ReadLine()
                .Split("|")
                .Reverse()
                .ToList();
            
            List<string> newNumbers = new List<string>();

            foreach (var item in numbers)
            {
                newNumbers.AddRange(item
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList());
            }

            Console.WriteLine(string.Join(" ", newNumbers));
        }
    }
}
