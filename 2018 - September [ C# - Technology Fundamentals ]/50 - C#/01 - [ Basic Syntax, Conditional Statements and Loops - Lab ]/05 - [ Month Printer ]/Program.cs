using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"};

            int month = int.Parse(Console.ReadLine());
            if (month <= 12 && month >= 1)
            {
                Console.WriteLine(months[month - 1]);
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
