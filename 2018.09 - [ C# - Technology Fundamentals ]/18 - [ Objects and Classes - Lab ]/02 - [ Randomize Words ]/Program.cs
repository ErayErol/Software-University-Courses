using System;
using System.Linq;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console
                .ReadLine()
                .Split()
                .ToList();

            var random = new Random();

            for (int i = 0; i < words.Count; i++)
            {
                int rand = random.Next(0, words.Count);
                string temp = words[i];
                words[i] = words[rand];
                words[rand] = temp;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
