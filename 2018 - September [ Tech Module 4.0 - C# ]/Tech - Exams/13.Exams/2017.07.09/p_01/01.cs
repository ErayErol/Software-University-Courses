using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());
            decimal m = decimal.Parse(Console.ReadLine());
            decimal y = decimal.Parse(Console.ReadLine());

            decimal nC = n;
            decimal divide = n / 2.0m;
            int count = 0;

            while (nC >= m)
            {
                count++;
                nC = nC - m;
                if (nC == divide && y > 0)
                {
                    nC = (int)nC / (int)y;
                }
            }

            Console.WriteLine(nC);
            Console.WriteLine(count);
        }
    }
}