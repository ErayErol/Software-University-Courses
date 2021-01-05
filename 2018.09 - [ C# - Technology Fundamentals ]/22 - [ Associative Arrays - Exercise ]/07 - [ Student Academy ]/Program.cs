using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < rowsCount; i++)
            {
                string studName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!dict.ContainsKey(studName))
                {
                    dict[studName] = new List<double>();
                }

                dict[studName].Add(grade);
            }

            dict = dict
                .Where(x => x.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine(string.Join(Environment.NewLine, 
                dict.Select(x => $"{x.Key} -> {x.Value.Average():f2}")));
        }
    }
}
