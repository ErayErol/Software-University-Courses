using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int sequenceLength = int.Parse(Console.ReadLine());

            int[] DNA = new int[sequenceLength];

            int lenght = 0;
            int index = 0;

            int row = 0;
            int currRow = 0;

            int sum = 0;

            string input = Console.ReadLine();

            while (input != "Clone them!")
            {
                int[] dnaSequence =
                    input.Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                currRow++;

                int currSum = 0;
                int currLength = 0;
                int currIndex = 0;

                int dnaLenght = dnaSequence.Length;
                int counter = 0;

                while (counter < dnaLenght)
                {
                    if (dnaSequence[counter] == 1)
                    {
                        currSum++;
                    }
                    
                    counter++;
                }

                counter = 0;

                while (counter < dnaLenght)
                {

                    if (dnaSequence[counter] == 1)
                    {
                        currLength++;

                        if (currLength == 1)
                        {
                            currIndex = counter;
                        }

                        if ((currLength > lenght) || (currLength == lenght && (index > currIndex || currSum > sum)))
                        {
                            sum = currSum;

                            lenght = currLength;
                            index = currIndex;

                            row = currRow;
                            DNA = dnaSequence;
                        }
                    }
                    else
                    {
                        currIndex = 0;
                        currLength = 0;
                    }

                    counter++;
                }

                input = Console.ReadLine();
            }

            if (row == 0)
            {
                row = 1;
            }

            Console.WriteLine($"Best DNA sample {row} with sum: {sum}.");

            foreach (int values in DNA)
            {
                Console.Write($"{values} ");
            }
        }
    }
}
