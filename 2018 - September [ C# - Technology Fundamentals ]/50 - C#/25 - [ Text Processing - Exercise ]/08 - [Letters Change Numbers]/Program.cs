using System;
using System.Collections.Generic;
using System.Linq;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> str = Console
                .ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<double> sums = new List<double>();


            for (int i = 0; i < str.Count; i++)
            {
                double currSum = 0;
                string currStringNumber = "";
                int numbersCount = 1;

                for (int j = 0; j < str[i].Length; j++)
                {
                    if (str[i][j] >= 48 && str[i][j] <= 57)
                    {
                        currStringNumber += str[i][j];
                        numbersCount++;
                    }
                }

                double currNumber = double.Parse(currStringNumber);
                currSum = currNumber;

                if (str[i][0] >= 65 && str[i][0] <= 90)
                {
                    currSum /= (str[i][0] - 64);
                }
                else
                {
                    currSum *= (str[i][0] - 96);
                }

                if (str[i][numbersCount] >= 65 && str[i][numbersCount] <= 90)
                {
                    currSum -= (str[i][numbersCount] - 64);
                }
                else
                {
                    currSum += (str[i][numbersCount] - 96);
                }

                sums.Add(currSum);
            }

            Console.WriteLine($"{sums.Sum():f2}");
        }
    }
}
