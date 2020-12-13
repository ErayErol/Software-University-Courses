namespace _07.EqualArrays
{
    using System;
    using System.Linq;

    class EqualArrays
    {
        static void Main(string[] args)
        {
            int[] nums1 =
                   Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

            int[] nums2 =
                   Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (nums1[i] != nums2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }

            int sum = nums1.Sum();
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}