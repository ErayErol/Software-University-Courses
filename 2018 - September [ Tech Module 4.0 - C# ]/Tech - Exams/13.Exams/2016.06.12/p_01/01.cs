using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> greaterThanAverage = new List<int>();

            bool isValid = false;

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] > nums.Average())
                {
                    greaterThanAverage.Add(nums[i]);
                    isValid = true;
                }
            }

            if (isValid)
            {
                greaterThanAverage.Sort();
                greaterThanAverage.Reverse();

                int length = greaterThanAverage.Count;
                if (length > 5)
                {
                    length = 5;
                }

                List<int> resultTop5 = new List<int>();
                for (int i = 0; i < length; i++)
                {
                    resultTop5.Add(greaterThanAverage[i]);
                }

                Console.WriteLine(string.Join(" ", resultTop5));
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
