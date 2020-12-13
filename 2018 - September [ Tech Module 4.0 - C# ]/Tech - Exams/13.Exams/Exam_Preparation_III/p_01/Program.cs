using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal totalSum = 0M;
            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                long capsulesCount = long.Parse(Console.ReadLine());

                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

                decimal currentPrice = ((decimal)(daysInMonth * (decimal)capsulesCount) * (decimal)pricePerCapsule);
                totalSum += currentPrice;

                Console.WriteLine($"The price for the coffee is: ${currentPrice:F2}");
            }

            Console.WriteLine($"Total: ${totalSum:F2}");
        }
    }
}
