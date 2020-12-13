namespace _11.MultiplicationTable2._0
{
    using System;

    class MultiplicationTable2
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());
            int result = 0;

            for (int i = times; i <= 10; i++)
            {
                result = n * i;
                Console.WriteLine($"{n} X {i} = {result}");
            }

            if (times > 10)
            {
                result = n * times;
                Console.WriteLine($"{n} X {times} = {result}");
            }
        }
    }
}