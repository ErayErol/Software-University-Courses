namespace _07.VendingMachine
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            decimal nuts = 2.0m;
            decimal water = 0.7m;
            decimal crisps = 1.5m;
            decimal soda = 0.8m;
            decimal coke = 1.0m;

            decimal number = 0.0m;
            decimal sum = 0.0m;

            string commands = Console.ReadLine();

            while (true)
            {
                if (commands == "Start")
                {
                    break;
                }

                switch (commands)
                {
                    case "Start":
                        return;
                    case "2":
                        number = decimal.Parse(commands); sum += number;
                        break;
                    case "1":
                        number = decimal.Parse(commands); sum += number;
                        break;
                    case "0.5":
                        number = decimal.Parse(commands); sum += number;
                        break;
                    case "0.2":
                        number = decimal.Parse(commands); sum += number;
                        break;
                    case "0.1":
                        number = decimal.Parse(commands); sum += number;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {commands}");
                        break;
                }

                commands = Console.ReadLine();
            }

            string commands2 = Console.ReadLine();
            while (true)
            {
                if (commands2 == "End")
                {
                    break;
                }

                if (commands2 == "Nuts")
                {
                    sum -= nuts;
                    if (sum < 0.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        sum += nuts;
                    }
                    else
                    {
                        Console.WriteLine($"Purchased nuts");
                    }
                }
                else if (commands2 == "Water")
                {
                    sum -= water;
                    if (sum < 0.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        sum += water;
                    }
                    else
                    {
                        Console.WriteLine($"Purchased water");
                    }
                }
                else if (commands2 == "Crisps")
                {
                    sum -= crisps;
                    if (sum < 0.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        sum += crisps;
                    }
                    else
                    {
                        Console.WriteLine($"Purchased crisps");
                    }
                }
                else if (commands2 == "Soda")
                {
                    sum -= soda;
                    if (sum < 0.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        sum += soda;
                    }
                    else
                    {
                        Console.WriteLine($"Purchased soda");
                    }
                }
                else if (commands2 == "Coke")
                {
                    sum -= coke;
                    if (sum < 0.0m)
                    {
                        Console.WriteLine("Sorry, not enough money");
                        sum += coke;
                    }
                    else
                    {
                        Console.WriteLine($"Purchased coke");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                commands2 = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum:F2}");
        }
    }
}