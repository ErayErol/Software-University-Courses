namespace _03.Vacation
{
    using System;

    class Vacation
    {
        static void Main(string[] args)
        {
            int groupOfPeople = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0.0;
            switch (type)
            {
                case "Students":
                    switch (day)
                    {
                        case "Monday": price = 9.5; break;
                        case "Tuesday": price = 8; break;
                        case "Wednesday": price = 6.85; break;
                        case "Thursday": price = 7.15; break;
                        case "Friday": price = 8.45; break;
                        case "Saturday": price = 9.8; break;
                        case "Sunday": price = 10.46; break;
                    }

                    price = price * groupOfPeople;

                    if (groupOfPeople >= 30)
                    {
                        price = price * 0.85; 
                    }

                    break;
                case "Business":
                    switch (day)
                    {
                        case "Monday": price = 11.8; break;
                        case "Tuesday": price = 14.5; break;
                        case "Wednesday": price = 12.6; break;
                        case "Thursday": price = 13.20; break;
                        case "Friday": price = 10.90; break;
                        case "Saturday": price = 15.6; break;
                        case "Sunday": price = 16; break;
                    }

                    if (groupOfPeople >= 100)
                    {
                        groupOfPeople = groupOfPeople - 10;
                    }

                    price = price * groupOfPeople;

                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Monday": price = 15; break;
                        case "Tuesday": price = 15; break;
                        case "Wednesday": price = 14.8; break;
                        case "Thursday": price = 13.9; break;
                        case "Friday": price = 15; break;
                        case "Saturday": price = 20; break;
                        case "Sunday": price = 22.5; break;
                    }

                    price = price * groupOfPeople;

                    if (groupOfPeople >= 10 && groupOfPeople <= 20)
                    {
                        price = price * 0.95;
                    }

                    break;
            }

            Console.WriteLine($"Total price: {price:F2}");
        }
    }
}