namespace _09.PokeMon
{
    using System;

    class PokeMon
    {
        static void Main(string[] args)
        {
            decimal n = decimal.Parse(Console.ReadLine());
            decimal m = decimal.Parse(Console.ReadLine());
            decimal y = decimal.Parse(Console.ReadLine());

            decimal nC = n;
            decimal divise = 0.0M;
            int count = 0;

            while (true)
            {
                if (nC < m)
                {
                    break;
                }

                nC = nC - m;
                if (nC == n / 2.0M && y != 0)
                {
                    divise = (int)nC / (int)y;
                    if (divise >= 0)
                    {
                        nC = divise;
                    }
                }

                count++;
            }

            Console.WriteLine(nC);
            Console.WriteLine(count);
        }
    }
}