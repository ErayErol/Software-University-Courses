using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> commands = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == commands[0])
                {
                    int start = i - commands[1];
                    if (start < 0)
                    {
                        start = 0;
                    }

                    int finish = i + commands[1] + 1;
                    if (finish > numbers.Count)
                    {
                        finish = numbers.Count;
                    }

                    for (int j = start; j < finish; j++)
                    {
                        numbers[j] = 0;
                    }
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
