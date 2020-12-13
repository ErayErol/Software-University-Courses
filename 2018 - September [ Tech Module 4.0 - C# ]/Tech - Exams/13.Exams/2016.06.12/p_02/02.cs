using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfOrders = int.Parse(Console.ReadLine());

            decimal price = 0m;
            decimal totalPrice = 0m;

            for (int i = 0; i < countOfOrders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                decimal capsulesCount = decimal.Parse(Console.ReadLine());

                price = ((DateTime.DaysInMonth(orderDate.Year, orderDate.Month) * capsulesCount) * pricePerCapsule);
                totalPrice += price;

                Console.WriteLine($"The price for the coffee is: ${price:F2}");
            }

            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}