using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
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

            List<int> bombNumberAndHisPower = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();


            int indexBomb = numbers.IndexOf(bombNumberAndHisPower[0]);

            while (indexBomb != -1)
            {
                int leftNumber = indexBomb - bombNumberAndHisPower[1];
                int rightNumber = indexBomb + bombNumberAndHisPower[1];

                if (leftNumber < 0)
                {
                    leftNumber = 0;
                }

                if (rightNumber > numbers.Count)
                {
                    rightNumber = numbers.Count - 1;
                }

                numbers.RemoveRange(leftNumber, ++rightNumber - leftNumber);
                indexBomb = numbers.IndexOf(bombNumberAndHisPower[0]);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
