using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)

        {
            List<int> numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = 0;
            int removed = 0;

            while (numbers.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    removed = numbers[0];
                    sum += removed;
                    numbers[0] = numbers[numbers.Count - 1];
                }
                else if (index >= numbers.Count)
                {
                    removed = numbers[numbers.Count - 1];
                    sum += removed;
                    numbers[numbers.Count - 1] = numbers[0];
                }
                else
                {
                    removed = numbers[index];
                    sum += numbers[index];
                    numbers.RemoveAt(index);
                }

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (removed >= numbers[i])
                    {
                        numbers[i] += removed;
                    }
                    else if (removed < numbers[i])
                    {
                        numbers[i] -= removed;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
