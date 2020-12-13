using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.ExtractSentencesByKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int skip = nums[0];
            int take = nums[1];
            string text = Console.ReadLine();
            string pattern = @"\|<([\w]{" + skip + @"})([\w]{0," + take + @"})";
            MatchCollection regex = Regex.Matches(text, pattern);
            List<string> result = new List<string>();

            foreach (Match match in regex)
            {
                result.Add(match.Groups[2].Value);
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}