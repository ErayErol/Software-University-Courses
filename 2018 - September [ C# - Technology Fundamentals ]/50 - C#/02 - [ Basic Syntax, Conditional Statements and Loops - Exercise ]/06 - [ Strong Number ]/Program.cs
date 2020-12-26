using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int copyOfTheNumber = number;
            int factSum = 0;
            int currNum = 0;

            while (copyOfTheNumber != 0)
            {
                currNum = copyOfTheNumber % 10;
                copyOfTheNumber = copyOfTheNumber / 10;

                int fact = 1;
                for (int i = 1; i <= currNum; i++)
                {
                    fact *= i;
                }
                factSum += fact;
            }
            if (number == factSum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
