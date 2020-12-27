using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> key = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string treasureName = @"&(?<treasure>\w+)&";
            string coordinates = @"<(?<coords>\w+)>";

            var dict = new Dictionary<string, string>();

            string input;
            while ((input = Console.ReadLine()) != "find")
            {
                string decryptedMessage = "";
                int currKeyIndex = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    decryptedMessage += (char)(input[i] - key[currKeyIndex]);

                    currKeyIndex++;
                    if (currKeyIndex >= key.Count)
                    {
                        currKeyIndex = 0;
                    }
                }

                var treasureMatch = Regex.Match(decryptedMessage, treasureName);
                var coordsMatch = Regex.Match(decryptedMessage, coordinates);

                dict.Add(treasureMatch.Groups["treasure"].Value, coordsMatch.Groups["coords"].Value);
            }

            Console.WriteLine(string.Join(Environment.NewLine, dict
                .Select(x => $"Found {x.Key} at {x.Value}")));
        }
    }
}
