using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split('|').ToList();

            string first = text[0];
            string second = text[1];
            string third = text[2];

            var pattern = @"([#|$|%|*|&])[A-Z]+\1";
            string firstSymbols = "";
            foreach (var match in Regex.Matches(first, pattern))
            {
                firstSymbols = match.ToString();
            }

            string s = firstSymbols[0].ToString();
            firstSymbols = firstSymbols.Replace(s, string.Empty).ToString();
            var pattern2 = @"\d{2}:\d{2}";
            string secondSymbols = "";
            char[] firstSymbolsChars = firstSymbols.ToCharArray();
            List<int> firstSymbolsInt = new List<int>();

            for (int i = 0; i < firstSymbolsChars.Length; i++)
            {
                int current = firstSymbolsChars[i];
                firstSymbolsInt.Add(current);
            }

            var symbolLenght = new Dictionary<string, int>();
            foreach (var lengthMatch in Regex.Matches(second, pattern2))
            {
                List<int> currentSplit = lengthMatch.ToString().Split(':').Select(int.Parse).ToList();
                if (symbolLenght.ContainsKey(currentSplit[0].ToString()) == false)
                {
                    symbolLenght.Add(currentSplit[0].ToString(), 0);
                }
                else
                {
                    symbolLenght.Remove(currentSplit[0].ToString());
                    string num = new string(currentSplit[0].ToString());
                    symbolLenght.Add(new string(num), 0);
                }
                symbolLenght[currentSplit[0].ToString()] = currentSplit[1];
            }

            string[] firstSplitted = first.Split();
            string[] thirdSplitted = third.Split();
            List<string> result = new List<string>();

            foreach (var kvp in symbolLenght)
            {
                int token = int.Parse(kvp.Key);
                int length2 = kvp.Value;
                for (int e = 0; e < firstSplitted.Length; e++)
                {
                    bool isValid = false;
                    for (int i = 0; i < firstSplitted[e].Length; i++)
                    {
                        char currentInt = firstSplitted[e][i];
                        if (currentInt == token)
                        {
                            if (firstSplitted[e].Length - 1 == length2)
                            {
                                result.Add(firstSplitted[e].ToString());
                                isValid = true;
                            }
                        }
                        break;
                    }

                    if (isValid)
                    {
                        break;
                    }
                }

                for (int e = 0; e < thirdSplitted.Length; e++)
                {
                    bool isValid = false;
                    for (int i = 0; i < thirdSplitted[e].Length; i++)
                    {
                        char currentInt = thirdSplitted[e][i];
                        if (currentInt == token)
                        {
                            if (thirdSplitted[e].Length - 1 == length2)
                            {
                                result.Add(thirdSplitted[e].ToString());
                                isValid = true;
                            }
                        }
                        break;
                    }

                    if (isValid)
                    {
                        break;
                    }
                }
            }

            foreach (var message in result)
            {
                Console.WriteLine(message);
            }

        }
    }
}