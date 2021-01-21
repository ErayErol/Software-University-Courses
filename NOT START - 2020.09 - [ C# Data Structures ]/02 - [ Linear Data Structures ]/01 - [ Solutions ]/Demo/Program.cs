using System.Linq;

namespace Demo
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[4];
            nums[0] = 1;
            nums[1] = 2;
            nums[2] = 3;
            nums.Select(x => Console.WriteLine(x));
        }
    }
}
