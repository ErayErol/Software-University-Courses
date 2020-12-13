namespace _04.TheKitchen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TheKitchen
    {
        static void Main(string[] args)
        {
            KnivesAndForks(out var set);
            Console.WriteLine($"The biggest set is: {set.Max()}\n{string.Join(" ", set)}");
        }

        private static void KnivesAndForks(out List<int> set)
        {
            var knives = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var forks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            set = new List<int>();

            while (knives.Any() && forks.Any())
            {
                var fork = forks.Peek();
                var knive = knives.Pop();

                if (knive > fork)
                {
                    set.Add(forks.Dequeue() + knive);
                }
                else if (fork == knive)
                {
                    forks.Dequeue();
                    knive++;
                    knives.Push(knive);
                }
            }
        }
    }
}