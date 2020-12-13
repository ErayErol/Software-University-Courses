namespace _07.PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PredicateForNames
    {
        static void Main(string[] args)
        {
            Action<List<string>> print = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            int length = int.Parse(Console.ReadLine());
            Predicate<string> predicate = x => x.Length <= length;

            var names = Console.ReadLine()
                .Split()
                .ToList();

            names = names.FindAll(predicate);
            print(names);
        }
    }
}