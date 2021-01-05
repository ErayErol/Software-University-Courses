using System;

namespace BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int totalMinutes = (hours * 60) + minutes;
            int minutesAfter30 = totalMinutes + 30;

            int finalHours = minutesAfter30 / 60;
            int finalMinutes = minutesAfter30 % 60;

            if (finalHours > 23)
            {
                finalHours = 0;
            }
            
            Console.WriteLine($"{finalHours}:{finalMinutes:d2}");
        }
    }
}
