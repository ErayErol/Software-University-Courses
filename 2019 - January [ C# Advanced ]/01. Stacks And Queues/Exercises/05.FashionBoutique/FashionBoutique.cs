using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class FashionBoutique
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse);
            var clothes = new Stack<int>(input);
            var capacity = int.Parse(Console.ReadLine());

            var sum = 0;
            var rack = 1;

            while (clothes.Any())
            {
                if (sum + clothes.Peek() <= capacity)
                {
                    sum += clothes.Pop();
                }
                else
                {
                    sum = 0;
                    rack++;
                }
            }

            Console.WriteLine(rack);
        }
    }
}