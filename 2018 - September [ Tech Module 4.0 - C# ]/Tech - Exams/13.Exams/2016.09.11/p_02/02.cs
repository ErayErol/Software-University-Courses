using System;
using System.Collections.Generic;
using System.Linq;

namespace p_02
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            int entryPolong = int.Parse(Console.ReadLine());
            string typeOfItems = Console.ReadLine();
            string typeOfPriceRating = Console.ReadLine();

            List<long> damageLeft = new List<long>();
            List<long> damageRight = new List<long>();
            List<long> sumLeft = new List<long>();
            List<long> sumRight = new List<long>();

            if (entryPolong < 1)
            {
                entryPolong = 1;
            }
            else if (entryPolong > nums.Length - 2)
            {
                entryPolong = nums.Length - 2;
            }

            switch (typeOfItems.ToLower())
            {
                case "cheap":
                    GetCheap(nums, entryPolong, damageLeft, damageRight);
                    break;
                case "expensive":
                    GetExpensive(nums, entryPolong, damageLeft, damageRight);
                    break;
            }

            switch (typeOfPriceRating.ToLower())
            {
                case "positive":
                    GetPositive(damageLeft, damageRight, sumLeft, sumRight);
                    break;
                case "negative":
                    GetNegative(damageLeft, damageRight, sumLeft, sumRight);
                    break;
                case "all":
                    GetAll(damageLeft, damageRight, sumLeft, sumRight);
                    break;
            }

            long totalSumLeft = sumLeft.Sum();
            long totalSumRight = sumRight.Sum();

            if (totalSumLeft >= totalSumRight)
            {
                Console.WriteLine("Left - {0}", totalSumLeft);
            }
            else
            {
                Console.WriteLine("Right - {0}", totalSumRight);
            }
        }

        static void GetAll(List<long> damageLeft, List<long> damageRight, List<long> sumLeft, List<long> sumRight)
        {
            // Left
            for (int i = 0; i < damageLeft.Count; i++)
            {
                sumLeft.Add(damageLeft[i]);
            }

            // Right
            for (int i = 0; i < damageRight.Count; i++)
            {
                sumRight.Add(damageRight[i]);
            }
        }

        static void GetNegative(List<long> damageLeft, List<long> damageRight, List<long> sumLeft, List<long> sumRight)
        {
            // Left
            for (int i = 0; i < damageLeft.Count; i++)
            {
                if (damageLeft[i] < 0)
                {
                    sumLeft.Add(damageLeft[i]);
                }
            }

            // Right
            for (int i = 0; i < damageRight.Count; i++)
            {
                if (damageRight[i] < 0)
                {
                    sumRight.Add(damageRight[i]);
                }
            }
        }

        static void GetPositive(List<long> damageLeft, List<long> damageRight, List<long> sumLeft, List<long> sumRight)
        {
            // Left
            for (int i = 0; i < damageLeft.Count; i++)
            {
                if (damageLeft[i] > 0)
                {
                    sumLeft.Add(damageLeft[i]);
                }
            }

            // Right
            for (int i = 0; i < damageRight.Count; i++)
            {
                if (damageRight[i] > 0)
                {
                    sumRight.Add(damageRight[i]);
                }
            }
        }

        static void GetExpensive(long[] nums, int entryPolong, List<long> damageLeft, List<long> damageRight)
        {
            // Left
            for (int i = 0; i < entryPolong; i++)
            {
                if (nums[i] >= nums[entryPolong])
                {
                    damageLeft.Add(nums[i]);
                }
            }

            // Right
            for (int i = entryPolong + 1; i < nums.Length; i++)
            {
                if (nums[i] >= nums[entryPolong])
                {
                    damageRight.Add(nums[i]);
                }
            }
        }

        static void GetCheap(long[] nums, int entryPolong, List<long> damageLeft, List<long> damageRight)
        {
            // Left
            for (int i = 0; i < entryPolong; i++)
            {
                if (nums[i] < nums[entryPolong])
                {
                    damageLeft.Add(nums[i]);
                }   
            }

            // Right
            for (int i = entryPolong + 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[entryPolong])
                {
                    damageRight.Add(nums[i]);
                }
            }
        }
    }
}