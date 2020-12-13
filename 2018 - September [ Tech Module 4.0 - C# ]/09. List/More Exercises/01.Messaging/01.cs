using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string text = Console.ReadLine();

            List<int> sumOfNums = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;
                char[] num = numbers[i].ToString().ToCharArray();

                for (int j = 0; j < num.Length; j++)
                {
                    sum = sum + int.Parse(num[j].ToString());
                }

                sumOfNums.Add(sum);
            }

            StringBuilder sb = new StringBuilder();

            bool isValid = false;

            for (int i = 0; i < sumOfNums.Count; i++)
            {
                for (int j = i; j < sumOfNums.Count; j++)
                {
                    if (sumOfNums[j] > text.Length)
                    {
                        sumOfNums[j] = sumOfNums[j] % text.Length;
                    }

                    if (isValid)
                    {
                        sumOfNums[j]++;
                    }
                }

                sb.Append(text[sumOfNums[i]]);
                text.Remove(sumOfNums[i], 1);

                isValid = true;
            }

            Console.WriteLine(sb.ToString());
        }
    }
}