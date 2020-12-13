namespace _01.DayОfWeek
{
    using System;

    class DayОfWeek
    {
        static void Main(string[] args)
        {
            string[] daysNames =
           {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
            };

            int days = int.Parse(Console.ReadLine());

            if (days >= 1 && days <= 7)
            {
                Console.WriteLine(daysNames[days - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}