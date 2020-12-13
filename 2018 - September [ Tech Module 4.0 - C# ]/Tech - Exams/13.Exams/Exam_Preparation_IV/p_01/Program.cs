using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amountOfCash = decimal.Parse(Console.ReadLine());
            decimal numberOfGuests = decimal.Parse(Console.ReadLine());
            decimal priceBananas = decimal.Parse(Console.ReadLine());
            decimal priceEggs = decimal.Parse(Console.ReadLine());
            decimal priceBerries = decimal.Parse(Console.ReadLine());

            decimal set = Math.Ceiling(numberOfGuests / 6);
            decimal sum = (set * (2 * priceBananas)) + (set * (4 * priceEggs)) + (set * ((decimal)0.2 * priceBerries));

            if (amountOfCash >= sum)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {sum:f2}lv.");
            }
            else
            {
                decimal diff = Math.Abs(amountOfCash - sum);
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {diff:f2}lv more.");
            }
        }
    }
}
