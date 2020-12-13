using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyMatirials = new Dictionary<string, int>();
            keyMatirials.Add("shards", 0);
            keyMatirials.Add("fragments", 0);
            keyMatirials.Add("motes", 0);

            var junkMaterials = new Dictionary<string, int>();

            while (true)
            {
                string[] junk = Console.ReadLine().Split();

                for (int i = 0; i < junk.Count(); i += 2)
                {
                    int quantity = int.Parse(junk[i]);
                    string materialName = junk[i + 1].ToLower();

                    if (keyMatirials.ContainsKey(materialName))
                    {
                        keyMatirials[materialName] += quantity;

                        if (keyMatirials[materialName] >= 250)
                        {
                            keyMatirials[materialName] -= 250;

                            switch (materialName)
                            {
                                case "shards": Console.WriteLine("Shadowmourne obtained!"); break;
                                case "fragments": Console.WriteLine("Valanyr obtained!"); break;
                                case "motes": Console.WriteLine("Dragonwrath obtained!"); break;
                            }

                            foreach (var material in keyMatirials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                            {
                                Console.WriteLine($"{material.Key}: {material.Value}");
                            }

                            foreach (var junkMaterial in junkMaterials.OrderBy(x => x.Key))
                            {
                                Console.WriteLine($"{junkMaterial.Key}: {junkMaterial.Value}");
                            }

                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(materialName))
                        {
                            junkMaterials.Add(materialName, quantity);
                        }
                        else
                        {
                            junkMaterials[materialName] += quantity;
                        }
                    }
                }
            }
        }
    }
}