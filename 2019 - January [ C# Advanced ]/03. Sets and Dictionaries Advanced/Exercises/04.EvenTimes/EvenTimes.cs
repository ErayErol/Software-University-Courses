using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            var nums = new Dictionary<int, int>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (nums.ContainsKey(currentNum) == false)
                {
                    nums.Add(currentNum, 0);
                }

                nums[currentNum]++;
            }

            foreach (var number in nums.Where(n => n.Value % 2 == 0))
            {
                Console.WriteLine(number.Key);
            }
        }
    }
}