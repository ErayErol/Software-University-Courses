using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            GetTopNumber(number);
        }

        static void GetTopNumber(int number)
        {
            int result = 0;
            int last = 0;
            int between100And1000 = 0;
            int first = 0;

            for (int i = 17; i < number; i++)
            {
                if (i < 100)
                {
                    last = i % 10;
                    first = i / 10;

                    result = first + last;
                }
                else if (i < 1000)
                {
                    last = i % 10;
                    between100And1000 = (i / 10) % 10;
                    first = i / 100;

                    result = first + between100And1000 + last;
                }
                

                if (result % 8 == 0 ||
                    result % 16 == 0 ||
                    result % 88 == 0)
                {
                    if (last % 2 == 1 || first % 2 == 1 || between100And1000 % 2 == 1)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    }
}
