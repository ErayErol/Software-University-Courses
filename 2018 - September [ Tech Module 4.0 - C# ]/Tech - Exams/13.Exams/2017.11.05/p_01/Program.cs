using System;
using System.Numerics;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfAffectiveWebsite = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());

            decimal totalLoss = 0m;
            for (int i = 1; i <= countOfAffectiveWebsite; i++)
            {
                string[] data = Console.ReadLine().Split();

                string siteName = data[0];
                Console.WriteLine(siteName);

                long siteVisit = long.Parse(data[1]);
                decimal pricePerVisit = decimal.Parse(data[2]);

                decimal num = siteVisit * pricePerVisit;
                totalLoss += num;
            }

            Console.WriteLine($"Total Loss: {totalLoss:F20}");

            BigInteger securityToken = BigInteger.Pow(securityKey, countOfAffectiveWebsite);
            Console.WriteLine($"Security Token: {securityToken}");
        }
    }
}