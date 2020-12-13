using System;
using System.Collections.Generic;
using System.Linq;

namespace p_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, Dictionary<string, decimal>>();
            var cache = new Dictionary<string, Dictionary<string, decimal>>();
            List<string> listOfDataSets = new List<string>();

            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(new char[] { ' ', '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "thetinggoesskrra")
                {
                    decimal first = 0.0m;
                    decimal second = 0.0m;
                    for (int i = 0; i < listOfDataSets.Count; i++)
                    {
                        if (cache.ContainsKey(listOfDataSets[i]))
                        {
                            first = cache.Values.SelectMany(dict => dict.Values.ToList()).Sum();
                        }
                        if (data.ContainsKey(listOfDataSets[i]))
                        {
                            second = data.Values.SelectMany(dict => dict.Values.ToList()).Sum();
                        }
                    }

                    var result = new Dictionary<string, Dictionary<string, decimal>>();
                    if (first > second)
                    {
                        result = cache;
                    }
                    else
                    {
                        result = data;
                    }

                    foreach (var kvp in result.OrderByDescending(a => a.Value.Values.Sum()))
                    {
                        Console.WriteLine($"Data Set: {kvp.Key}, Total Size: {kvp.Value.Values.Sum()}");
                        foreach (var dataKeys in kvp.Value)
                        {
                            Console.WriteLine($"$.{string.Join("", dataKeys.Key)}");
                        }
                        return;
                    }

                    break;
                }

                if (commands.Length == 1)
                {
                    listOfDataSets.Add(commands[0]);
                    continue;
                }

                string dataKey = commands[0];
                decimal dataSize = decimal.Parse(commands[1]);
                string dataSet = commands[2];

                if (listOfDataSets.Contains(dataSet)) // if currentDataSet is contain in listOfDataSets
                {
                    if (data.ContainsKey(dataSet) == false) // if currentDataSet is NOT contain in data
                    {
                        data.Add(dataSet, new Dictionary<string, decimal>());
                    }
                    data[dataSet].Add(dataKey, dataSize);
                }
                else // if currentDataSet is NOT contain in listOfDataSets
                {
                    if (cache.ContainsKey(dataSet) == false) // if currentDataSet is NOT contains in cache
                    {
                        cache.Add(dataSet, new Dictionary<string, decimal>());
                    }
                    cache[dataSet].Add(dataKey, dataSize);
                }
            }
        }
    }
}