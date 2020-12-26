using System;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());

            double outFallFourPrice = 39.99;
            double csOgPrice = 15.99;
            double zplinterZellPrice = 19.99;
            double honoredTwoPrice = 59.99;
            double roverWatchPrice = 29.99;
            double roverWatchOriginsEditionPrice = 39.99;

            bool flag = false;
            double totalSpentCounter = 0;

            string gameName = Console.ReadLine();
            while (gameName != "Game Time")
            {
                if (gameName == "OutFall 4")
                {
                    if (currentBalance >= outFallFourPrice)
                    {
                        flag = true;
                        currentBalance -= outFallFourPrice;
                        totalSpentCounter += outFallFourPrice;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "CS: OG")
                {
                    if (currentBalance >= csOgPrice)
                    {
                        flag = true;
                        currentBalance -= csOgPrice;
                        totalSpentCounter += csOgPrice;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "Zplinter Zell")
                {
                    if (currentBalance >= zplinterZellPrice)
                    {
                        flag = true;
                        currentBalance -= zplinterZellPrice;
                        totalSpentCounter += zplinterZellPrice;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "Honored 2")
                {
                    if (currentBalance >= honoredTwoPrice)
                    {
                        flag = true;
                        currentBalance -= honoredTwoPrice;
                        totalSpentCounter += honoredTwoPrice;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "RoverWatch")
                {
                    if (currentBalance >= roverWatchPrice)
                    {
                        flag = true;
                        currentBalance -= roverWatchPrice;
                        totalSpentCounter += roverWatchPrice;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else if (gameName == "RoverWatch Origins Edition")
                {
                    if (currentBalance >= roverWatchOriginsEditionPrice)
                    {
                        flag = true;
                        currentBalance -= roverWatchOriginsEditionPrice;
                        totalSpentCounter += roverWatchOriginsEditionPrice;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }

                if (flag)
                {
                    Console.WriteLine($"Bought {gameName}");
                    flag = false;
                }

                if (currentBalance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }

                gameName = Console.ReadLine();
            }

            if (gameName == "Game Time")
            {
                Console.WriteLine($"Total spent: ${totalSpentCounter:f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}
