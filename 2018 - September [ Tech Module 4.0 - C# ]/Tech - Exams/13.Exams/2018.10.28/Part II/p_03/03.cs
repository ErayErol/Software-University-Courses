using System;
using System.Text.RegularExpressions;

namespace p_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSum = 0;
            int dishes = 0;
            int cleaning = 0;
            int laundry = 0;

            while (true)
            {
                string commands = Console.ReadLine();
                if (commands == "wife is happy")
                {
                    Console.WriteLine($"Doing the dishes - {dishes} min.");
                    Console.WriteLine($"Cleaning the house - {cleaning} min.");
                    Console.WriteLine($"Doing the laundry - {laundry} min.");
                    Console.WriteLine($"Total - {totalSum} min.");
                    break;
                }

                int currentDishes = 0;
                int currentCleaning = 0;
                int currentLaundry = 0;
                string currentText = "";

                string patternForDishes = @"(?<=\<)([a-z0-9]+)(?=\>)";
                MatchCollection regexForDishes = Regex.Matches(commands, patternForDishes);
                foreach (Match match in regexForDishes)
                {
                    currentText = match.ToString();
                    for (int i = 0; i < currentText.Length; i++)
                    {
                        if (char.IsDigit(currentText[i]))
                        {
                            currentDishes += int.Parse(currentText[i].ToString());
                        }
                    }

                    dishes += currentDishes;
                    totalSum += currentDishes;
                }

                string patternForCleaning = @"(?<=\[)([A-Z0-9]+)(?=\])";
                MatchCollection regexForCleaning = Regex.Matches(commands, patternForCleaning);
                foreach (Match match in regexForCleaning)
                {
                    currentText = match.ToString();
                    for (int i = 0; i < currentText.Length; i++)
                    {
                        if (char.IsDigit(currentText[i]))
                        {
                            currentCleaning += int.Parse(currentText[i].ToString());
                        }
                    }

                    cleaning += currentCleaning;
                    totalSum += currentCleaning;
                }

                string patternForLaundry = @"(?<=\{)(.+)(?=\})";
                MatchCollection regexForLaundry = Regex.Matches(commands, patternForLaundry);
                foreach (Match match in regexForLaundry)
                {
                    currentText = match.ToString();
                    for (int i = 0; i < currentText.Length; i++)
                    {
                        if (char.IsDigit(currentText[i]))
                        {
                            currentLaundry += int.Parse(currentText[i].ToString());
                        }
                    }

                    laundry += currentLaundry;
                    totalSum += currentLaundry;
                }
            }
        }
    }
}