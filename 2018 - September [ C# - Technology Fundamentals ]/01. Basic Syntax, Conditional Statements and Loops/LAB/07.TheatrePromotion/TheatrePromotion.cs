namespace _07.TheatrePromotion
{
    using System;

    class TheatrePromotion
    {
        static void Main(string[] args)
        {
            var day = Console.ReadLine().ToLower();
            var age = int.Parse(Console.ReadLine());
            var price = 0;

            if (age < 0)
            {
                Console.WriteLine("Error!");
                return;
            }

            switch (day)
            {
                case "weekday":
                    if (0 <= age && age <= 18 || 64 < age && age <= 122)
                    {
                        price = 12;
                    }
                    else if (18 < age && age <= 64)
                    {
                        price = 18;
                    }
                    break;
                case "weekend":
                    if (0 <= age && age <= 18 || 64 < age && age <= 122)
                    {
                        price = 15;
                    }
                    else if (18 < age && age <= 64)
                    {
                        price = 20;
                    }
                    break;
                case "holiday":
                    if (0 <= age && age <= 18)
                    {
                        price = 5;
                    }
                    else if (18 < age && age <= 64)
                    {
                        price = 12;
                    }
                    else if (64 < age && age <= 122)
                    {
                        price = 10;
                    }
                    break;
            }

            if (price > 0)
            {
                Console.WriteLine($"{price}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}