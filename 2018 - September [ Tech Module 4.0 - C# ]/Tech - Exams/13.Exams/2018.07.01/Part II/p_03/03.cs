using System;
using System.Text.RegularExpressions;

namespace p_03
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalResult = 0.0m;
            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "end of shift")
                {
                    Console.WriteLine($"Total income: {totalResult:F2}");
                    break;
                }

                bool boolName = false;
                bool boolProduct = false;
                bool boolCount = false;
                bool boolPrice = false;

                string stringName = "";
                string stringProduct = "";
                int count = 0;
                decimal price = 0.0m;

                string patternForName = @"(?<=%)[A-Z]{1}[a-z]+(?=%)";
                foreach (var match in Regex.Matches(commands, patternForName))
                {
                    boolName = true;
                    stringName = match.ToString();
                }

                string patternForProduct = @"(?<=<)\w+(?=>)";
                foreach (var match in Regex.Matches(commands, patternForProduct))
                {
                    boolProduct = true;
                    stringProduct = match.ToString();
                }

                string patternForCount = @"(?<=\|)\d+(?=\|)";
                foreach (var match in Regex.Matches(commands, patternForCount))
                {
                    boolCount = true;
                    count = int.Parse(match.ToString());
                }

                string patternForPrice = @"[\d?]*[\.?|\d*]\d+(?=\$)";
                foreach (var match in Regex.Matches(commands, patternForPrice))
                {
                    boolPrice = true;
                    price = decimal.Parse(match.ToString());
                }


                decimal currentResult = 0.0m;
                if (boolName == true && boolProduct == true && boolCount == true && boolPrice == true)
                {
                    currentResult = price * count;

                    Console.WriteLine($"{stringName}: {stringProduct} - {currentResult:F2}");

                    totalResult += currentResult;
                }
            }
        }
    }
}