namespace _09._Rage_Quit
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            Regex pattern = new Regex(@"(\D+)(\d+)");

            StringBuilder message = new StringBuilder();

            string input = Console.ReadLine().ToUpper();

            foreach (Match patternMatch in pattern.Matches(input))
            {
                string curentStr = patternMatch.Groups[1].Value;
                int repeats = int.Parse(patternMatch.Groups[2].Value);

                for (int i = 0; i < repeats; i++)
                {
                    message.Append(curentStr);
                }
            }

            Console.WriteLine($"Unique symbols used: {message.ToString().Distinct().Count()}");
            Console.WriteLine(message);
        }
    }
}