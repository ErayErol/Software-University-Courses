using System;

namespace TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfTheDay = Console.ReadLine();
            int personAge = int.Parse(Console.ReadLine());

            double ticketPrice = 0;
            if (typeOfTheDay == "Weekday")
            {
                if (0 <= personAge && personAge <= 18)
                {
                    ticketPrice = 12;
                }
                else if (18 < personAge && personAge <= 64)
                {
                    ticketPrice = 18;
                }
                else if (64 < personAge && personAge <= 122)
                {
                    ticketPrice = 12;
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            else if (typeOfTheDay == "Weekend")
            {
                if (0 <= personAge && personAge <= 18)
                {
                    ticketPrice = 15;
                }
                else if (18 < personAge && personAge <= 64)
                {
                    ticketPrice = 20;
                }
                else if (64 < personAge && personAge <= 122)
                {
                    ticketPrice = 15;
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            else if (typeOfTheDay == "Holiday")
            {
                if (0 <= personAge && personAge <= 18)
                {
                    ticketPrice = 5;
                }
                else if (18 < personAge && personAge <= 64)
                {
                    ticketPrice = 12;
                }
                else if (64 < personAge && personAge <= 122)
                {
                    ticketPrice = 10;
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            if (ticketPrice > 0)
            {
                Console.WriteLine($"{ticketPrice}$");
            }

        }
    }
}
