using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            decimal totalSum = 0.0m;
            decimal firstSum = 0.0m;
            decimal secondSum = 0.0m;

            for (int i = 0; i < input.Count; i++)
            {
                StringBuilder number = new StringBuilder();

                for (int j = 1; j < input[i].Length; j++)
                {
                    if (char.IsDigit(input[i][j]))
                    {
                        number.Append(input[i][j].ToString());
                        continue;
                    }
                    else
                    {
                        if (char.IsUpper(input[i][0]))
                        {
                            firstSum = decimal.Parse(number.ToString()) / (input[i][0] - 64);
                        }
                        else
                        {
                            firstSum = decimal.Parse(number.ToString()) * (input[i][0] - 96);
                        }

                        if (char.IsUpper(input[i][input[i].Length - 1]))
                        {
                            secondSum = firstSum - (input[i][input[i].Length - 1] - 64);
                        }
                        else
                        {
                            secondSum = firstSum + (input[i][input[i].Length - 1] - 96);
                        }
                    }

                    totalSum += secondSum;
                    break;
                }
            }

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}