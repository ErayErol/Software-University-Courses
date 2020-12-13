using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<int> numbers = new List<int>();
            List<string> nonNumber = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    numbers.Add(int.Parse(text[i].ToString()));
                }
                else
                {
                    nonNumber.Add(text[i].ToString());
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            StringBuilder sb = new StringBuilder();

            int indexForSkip = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> newNonNumber = new List<string>(nonNumber);

                newNonNumber = newNonNumber.Skip(indexForSkip).Take(takeList[i]).ToList();

                sb.Append(string.Join("", newNonNumber));

                indexForSkip += takeList[i] + skipList[i];
            }

            Console.WriteLine(sb.ToString());
        }
    }
}