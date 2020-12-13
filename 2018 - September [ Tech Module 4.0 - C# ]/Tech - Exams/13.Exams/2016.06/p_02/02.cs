using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            string[] commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (commands[0].ToLower() != "end")
            {
                switch (commands[0].ToLower())
                {
                    case "swap":
                        GetSwap(nums, commands);
                        break;
                    case "multiply":
                        GetMultiply(nums, commands);
                        break;
                    case "decrease":
                        GetDecrease(nums, commands);
                        break;
                }

                commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(", ", nums));
        }

        static void GetDecrease(List<long> nums, string[] commands)
        {
            for (int i = 0; i < nums.Count; i++)
            {
                nums[i] = nums[i] - 1;
            }
        }

        static void GetMultiply(List<long> nums, string[] commands)
        {
            int index0 = int.Parse(commands[1]);
            int index1 = int.Parse(commands[2]);

            var sum = nums[index0] * nums[index1];

            nums.Insert(index0, sum);
            nums.RemoveAt(index0 + 1);
        }

        static void GetSwap(List<long> nums, string[] commands)
        {
            int index0 = int.Parse(commands[1]);
            int index1 = int.Parse(commands[2]);

            if (index0 > index1)
            {
                int temp = index1;
                index1 = index0;
                index0 = temp;
            }

            nums.Insert(index1, nums[index0]);
            nums.Insert(index0, nums[index1 + 1]);

            nums.RemoveAt(index0 + 1);
            nums.RemoveAt(index1 + 1);
        }
    }
}
