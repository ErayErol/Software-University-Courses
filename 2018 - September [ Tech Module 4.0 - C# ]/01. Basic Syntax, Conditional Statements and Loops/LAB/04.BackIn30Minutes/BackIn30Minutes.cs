namespace _04.BackIn30Minutes
{
    using System;

    class BackIn30Minutes
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (hours < 0 || hours > 24)
            {
                return;
            }

            minutes += 30;

            if (minutes > 59)
            {
                hours += 1;
                minutes -= 60;
            }
            if (hours > 23)
            {
                hours = 0;
            }

            Console.WriteLine($"{hours}:{minutes:D2}");
        }
    }
}