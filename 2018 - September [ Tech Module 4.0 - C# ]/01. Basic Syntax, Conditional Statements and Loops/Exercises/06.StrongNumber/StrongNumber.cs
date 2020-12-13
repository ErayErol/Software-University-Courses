namespace _06.StrongNumber
{
    using System;

    class StrongNumber
    {
        static void Main(string[] args)
        {
            int factorielNumber = int.Parse(Console.ReadLine());
            var num = factorielNumber;
            var sum = 0;

            while (num > 0)
            {
                var currNum = num % 10;

                num = num / 10;

                var currFactorielNumber = currNum;

                for (int i = 1; i < currNum - 1; i++)
                {
                    currFactorielNumber += currFactorielNumber * i;
                }

                sum += currFactorielNumber;
            }

            if (factorielNumber == sum)
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