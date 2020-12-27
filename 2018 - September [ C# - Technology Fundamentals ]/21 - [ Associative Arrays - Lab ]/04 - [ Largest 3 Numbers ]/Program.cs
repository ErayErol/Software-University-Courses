using System;
using System.Linq;

namespace LargestThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).Take(3).ToList());
            
            foreach (var item in nums)
            {
                Console.Write(item + " ");
            }
        }
    }
}
