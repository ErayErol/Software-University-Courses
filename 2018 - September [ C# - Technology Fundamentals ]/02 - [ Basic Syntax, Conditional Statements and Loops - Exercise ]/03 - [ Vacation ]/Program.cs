using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleGroup = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double totalPrice = 0;
            if (groupType == "Students")
            {
                if (day == "Friday")
                {
                    totalPrice = 8.45 * peopleGroup;
                }
                else if (day == "Saturday")
                {
                    totalPrice = 9.80 * peopleGroup;
                }
                else if (day == "Sunday")
                {
                    totalPrice = 10.46 * peopleGroup;
                }

                if (peopleGroup >= 30)
                {
                    totalPrice -= totalPrice * 0.15;
                }
            }
            else if (groupType == "Business")
            {
                if (peopleGroup >= 100)
                {
                    peopleGroup -= 10;
                }

                if (day == "Friday")
                {
                    totalPrice = 10.90 * peopleGroup;
                }
                else if (day == "Saturday")
                {
                    totalPrice = 15.60 * peopleGroup;
                }
                else if (day == "Sunday")
                {
                    totalPrice = 16 * peopleGroup;
                }
            }
            else if (groupType == "Regular")
            {
                if (day == "Friday")
                {
                    totalPrice = 15 * peopleGroup;
                }
                else if (day == "Saturday")
                {
                    totalPrice = 20 * peopleGroup;
                }
                else if (day == "Sunday")
                {
                    totalPrice = 22.50 * peopleGroup;
                }

                if (peopleGroup >= 10 && peopleGroup <= 20)
                {
                    totalPrice -= totalPrice * 0.05;
                }
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
