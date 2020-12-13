using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace p_02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nums = Console.ReadLine().Split().ToList();
            string[] commands = Console.ReadLine().Split();

            while (commands[0].ToLower() != "end")
            {
                switch (commands[0].ToLower())
                {
                    case "reverse":
                        GetReverse(nums, commands);
                        break;
                    case "sort":
                        GetSort(nums, commands);
                        break;
                    case "rollleft":
                        GetRollLeft(nums, commands);
                        break;
                    case "rollright":
                        GetRollRight(nums, commands);
                        break;
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

        static void GetRollRight(List<string> nums, string[] commands)
        {
            int rotation = int.Parse(commands[1]);
            if (rotation < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            //for (int r = 0; r < rotation % nums.Count; r++)
            //{
            //    string temp = nums[nums.Count - 1];
            //    for (int i = nums.Count - 1; i > 0; i--)
            //    {
            //        nums[i] = nums[i - 1];
            //    }
            //    nums[0] = temp;
            //}

            rotation = rotation % nums.Count;
            for (int i = 0; i < rotation; i++)
            {
                nums.Insert(0, nums[nums.Count - 1]);
                nums.RemoveAt(nums.Count - 1);
            }
        }

        static void GetRollLeft(List<string> nums, string[] commands)
        {
            int rotation = int.Parse(commands[1]);
            if (rotation < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            //for (int r = 0; r < rotation % nums.Count; r++)
            //{
            //    string temp = nums[0];
            //    for (int i = 0; i < nums.Count - 1; i++)
            //    {
            //        nums[i] = nums[i + 1];
            //    }
            //    nums[nums.Count - 1] = temp;
            //}

            rotation = rotation % nums.Count;
            for (int i = 0; i < rotation; i++)
            {
                nums.Insert(nums.Count, nums[0]);
                nums.RemoveAt(0);
            }
        }

        static void GetSort(List<string> nums, string[] commands)
        {
            int start = int.Parse(commands[2]);
            int count = int.Parse(commands[4]);

            if (start < 0 || start >= nums.Count || count + start > nums.Count || count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            List<string> theNewStr = nums.Skip(start).Take(count).OrderBy(str => str).ToList();
            nums.RemoveRange(start, count);
            nums.InsertRange(start, theNewStr);
        }

        static void GetReverse(List<string> nums, string[] commands)
        {
            int start = int.Parse(commands[2]);
            int count = int.Parse(commands[4]);

            if (start < 0 || start >= nums.Count || count + start > nums.Count || count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            nums.Reverse(start, count);
        }
    }
}