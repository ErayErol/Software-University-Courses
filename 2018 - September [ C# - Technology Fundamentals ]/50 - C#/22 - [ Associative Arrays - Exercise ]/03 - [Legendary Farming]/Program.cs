using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new Dictionary<string, int>();

            items["shards"] = 0;
            items["fragments"] = 0;
            items["motes"] = 0;

            var junkItems = new SortedDictionary<string, int>();

            bool isCompleted;

            while (true)
            {
                List<string> startingMaterials = Console
                    .ReadLine()
                    .Split()
                    .Select(x => x.ToLower())
                    .ToList();

                isCompleted = false;

                for (int i = 0; i < startingMaterials.Count; i += 2)
                {
                    string itemName = startingMaterials[i + 1];
                    int count = int.Parse(startingMaterials[i]);

                    if (itemName == "shards")
                    {
                        items["shards"] += count;

                        if (items["shards"] >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            items["shards"] -= 250;
                            isCompleted = true;
                            
                            break;
                        }
                    }
                    else if (itemName == "fragments")
                    {
                        items["fragments"] += count;

                        if (items["fragments"] >= 250)
                        {
                            Console.WriteLine("Valanyr obtained!");
                            items["fragments"] -= 250;
                            isCompleted = true;
                            
                            break;
                        }
                    }
                    else if (itemName == "motes")
                    {
                        items["motes"] += count;

                        if (items["motes"] >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            items["motes"] -= 250;
                            isCompleted = true;
                            
                            break;
                        }
                    }
                    else
                    {
                        if (!junkItems.ContainsKey(itemName))
                        {
                            junkItems[itemName] = 0;

                        }

                        junkItems[itemName] += count;
                    }
                }

                if (isCompleted)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, items
                        .OrderByDescending(x => x.Value)
                        .ThenBy(x => x.Key)
                        .Select(x => $"{x.Key}: {x.Value}")));

                    Console.WriteLine(string.Join(Environment.NewLine, junkItems
                        .Select(x => $"{x.Key}: {x.Value}")));

                    break;
                }
            }
        }
    }
}
