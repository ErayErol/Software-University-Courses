using System;

namespace RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            bool flag = false;
            for (int i = 1; i <= counter; i++)
            {
                int sum = 0;
                int currNumber = i;
                while (currNumber > 0)
                {
                    sum += currNumber % 10;
                    currNumber /= 10;
                }
                flag = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", i, flag);
            }
        }
    }
}
