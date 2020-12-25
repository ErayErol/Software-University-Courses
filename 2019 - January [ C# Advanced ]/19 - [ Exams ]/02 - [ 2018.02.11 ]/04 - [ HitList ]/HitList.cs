namespace _04.HitList
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class HitList
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());
            var peopleDetails = new Dictionary<string, Dictionary<string, string>>();
            var peopleIndexes = new Dictionary<string, int>();

            while (true)
            {
                var commands = Console.ReadLine().Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

                if (Info(commands, peopleDetails, peopleIndexes, targetInfoIndex))
                {
                    Print(peopleDetails, peopleIndexes, targetInfoIndex);
                    break;
                }
            }
        }

        private static bool Info(string[] commands, Dictionary<string, Dictionary<string, string>> personDetails, 
            Dictionary<string, int> personIndexes, int targetInfoIndex)
        {
            if (commands[0] == "end transmissions")
            {
                return true;
            }

            var name = commands[0];

            var splittedCommand = commands[1].Split(';');

            if (personDetails.ContainsKey(name) == false)
            {
                personDetails.Add(name, new Dictionary<string, string>());
                personIndexes.Add(name, 0);
            }

            for (int i = 0; i < splittedCommand.Length; i++)
            {
                var splitedSplited = splittedCommand[i].Split(':');
                var key = splitedSplited[0];
                var value = splitedSplited[1];

                if (personDetails[name].ContainsKey(key) == false)
                {
                    personDetails[name].Add(key, value);
                    personIndexes[name] += key.Length;
                    personIndexes[name] += value.Length;
                }
                else
                {
                    personIndexes[name] -= personDetails[name][key].Length;
                    personDetails[name][key] = value;
                    personIndexes[name] += value.Length;
                }
            }

            return false;
        }

        private static void Print(Dictionary<string, Dictionary<string, string>> personDetails, Dictionary<string, int> personIndexes, int targetInfoIndex)
        {
            var killName = Console.ReadLine().Split();

            Console.WriteLine($"Info on {killName[1]}:");
            foreach (var kvp in personDetails.Where(x => x.Key == killName[1]))
            {
                foreach (var kv in kvp.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"---{kv.Key}: {kv.Value}");
                }
            }

            var index = personIndexes[killName[1]];
            Console.WriteLine($"Info index: {index}");

            if (index >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - index} more info.");
            }
        }
    }
}