using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            var names = new HashSet<string>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                names.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join("\r\n", names));
        }
    }
}