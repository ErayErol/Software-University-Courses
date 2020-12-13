using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers0 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> numbers1 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int minLength = Math.Min(numbers0.Count, numbers1.Count);
            int maxLength = Math.Max(numbers0.Count, numbers1.Count);

            StringBuilder added = new StringBuilder();

            for (int i = 0; i < minLength; i++)
            {
                added.Append(numbers0[i]).Append(" ").Append(numbers1[i]).Append(" ");
            }

            if (numbers0.Count > numbers1.Count)
            {
                maxLength = numbers0.Count;
                minLength = numbers1.Count;

                for (int i = minLength; i < maxLength; i++)
                {
                    added.Append(numbers0[i]).Append(" ");
                }
            }
            else
            {
                maxLength = numbers1.Count;
                minLength = numbers0.Count;

                for (int i = minLength; i < maxLength; i++)
                {
                    added.Append(numbers1[i]).Append(" ");
                }
            }

            Console.WriteLine(added);
        }
    }
}
