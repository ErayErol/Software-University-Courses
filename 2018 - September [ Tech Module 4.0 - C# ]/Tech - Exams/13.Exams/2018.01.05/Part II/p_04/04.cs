using System;
using System.Collections.Generic;
using System.Linq;

namespace p_04
{
    class Program
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<string, Dictionary<List<string>, int>>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" <:> ");

                if (commands[0] == "Once upon a time")
                {
                    break;
                }

                string name = commands[0];
                string currentColor = commands[1];
                int physics = int.Parse(commands[2]);
                List<string> colors = new List<string>();
                colors.Add(currentColor);

                if (dic.ContainsKey(name) == false)
                {
                    dic.Add(name, new Dictionary<List<string>, int>());
                    dic[name].Add(colors, physics);
                }
                else
                {
                    foreach (var kvp in dic)
                    {
                        var valid = kvp.Value.Keys.Contains(colors);
                        if (valid)
                        {
                            colors.Add(currentColor);
                            dic[name][colors] = physics;
                            break;
                        }
                    }

                    if (dic[name].ContainsKey(colors) == false)
                    {
                        dic[name].Add(colors, physics);
                    }
                    else
                    {
                        var previousPhysics = int.Parse(dic[currentColor].ToString());
                        if (physics > previousPhysics)
                        {
                            dic.Remove(currentColor);
                            colors.Add(currentColor);
                            dic[name].Add(colors, physics);
                        }
                    }
                }

                ;
            }
        }
    }
}