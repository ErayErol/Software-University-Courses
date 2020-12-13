using System;
using System.Collections.Generic;

namespace _05.RecordUniqueNames
{
    class RecordUniqueNames
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\r\n", set));
        }
    }
}