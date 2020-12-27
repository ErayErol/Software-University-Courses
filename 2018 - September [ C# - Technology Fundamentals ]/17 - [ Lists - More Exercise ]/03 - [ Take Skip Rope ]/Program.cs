using System;
using System.Collections.Generic;
using System.Linq;

namespace TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            List<int> numbersList = new List<int>();
            List<char> nonNumbersList = new List<char>();

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 48 && str[i] <= 57)
                {
                    numbersList.Add(int.Parse(str[i].ToString()));
                }
                else
                {
                    nonNumbersList.Add(str[i]);
                }
            }

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbersList[i]);
                }
                else
                {
                    skipList.Add(numbersList[i]);
                }
            }

            string result = string.Empty;
            int totalSkipped = 0;

            for (int i = 0; i < skipList.Count; i++)
            {
                int skippedCounter = skipList[i];
                int tookCounter = takeList[i];

                result += new string(nonNumbersList.Skip(totalSkipped).Take(tookCounter).ToArray());
                totalSkipped += skippedCounter + tookCounter;
            }

            Console.WriteLine(result);
        }
    }
}
