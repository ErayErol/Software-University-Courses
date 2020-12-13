using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _04.LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            // 7 3 5 8 -1 0 6 7

            var nums = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            if (nums.Count == 1)
            {
                Console.WriteLine(nums[0]);
                Environment.Exit(0);
            }

            var min = nums.Min();

            var index = nums.IndexOf(min);

            var mostLeftIndex = int.MaxValue;

            var maxLenth = int.MinValue;

        }
    }
}