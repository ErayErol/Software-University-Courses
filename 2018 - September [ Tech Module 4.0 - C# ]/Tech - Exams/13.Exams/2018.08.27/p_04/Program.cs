using System;
using System.Collections.Generic;
using System.Linq;

namespace p_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var townNameTimePassengersCount = new Dictionary<string, Dictionary<int, long>>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(":");

                if (commands[0] == "Slide rule")
                {
                    foreach (var kvp in townNameTimePassengersCount
                        .Where(a => a.Value.Keys.Min() > 0)
                        .Where(a => a.Value.Values.Max() > 0)
                        .OrderBy(a => a.Value.Keys.Min())
                        .ThenBy(a => a.Key))
                    {
                        Console.WriteLine($"{kvp.Key} -> Time: {kvp.Value.Keys.Min()} -> Passengers: {kvp.Value.Values.Max()}");
                    }

                    break;
                }

                string[] commandsSplitted1 = commands[1].Split("->");
                string town = commands[0];
                string timeOrAmbush = commandsSplitted1[0];
                long passengersCount = long.Parse(commandsSplitted1[1]);

                int currentTime = 0;
                if (timeOrAmbush != "ambush")
                {
                    currentTime = int.Parse(timeOrAmbush);
                }

                if (townNameTimePassengersCount.ContainsKey(town) == false)
                {
                    if (timeOrAmbush == "ambush")
                    {
                        continue;
                    }

                    townNameTimePassengersCount.Add(town, new Dictionary<int, long>());
                    townNameTimePassengersCount[town].Add(currentTime, passengersCount);
                }
                else
                {
                    if (timeOrAmbush == "ambush")
                    {
                        var key = townNameTimePassengersCount[town].Keys.Max();
                        townNameTimePassengersCount[town][key] -= passengersCount;
                        var value = townNameTimePassengersCount[town][key];
                        townNameTimePassengersCount[town].Remove(key);
                        townNameTimePassengersCount[town].Add(0, value);
                    }
                    else
                    {
                        var time = townNameTimePassengersCount[town].Keys.Min();

                        townNameTimePassengersCount[town][time] += passengersCount;
                        if (time > currentTime || time == 0)
                        {
                            var value = townNameTimePassengersCount[town][time];
                            townNameTimePassengersCount[town].Remove(time);
                            townNameTimePassengersCount[town].Add(currentTime, value);
                        }
                    }
                }
            }
        }
    }
}