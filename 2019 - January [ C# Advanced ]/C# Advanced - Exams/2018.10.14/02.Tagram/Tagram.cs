namespace _02.Tagram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Tagram
    {
        static void Main(string[] args)
        {
            var userTags = new Dictionary<string, Dictionary<string, int>>();
            AddUsers(userTags);
            Print(userTags);
        }

        private static void Print(Dictionary<string, Dictionary<string, int>> userTags)
        {
            foreach (var user in userTags.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Keys.Count))
            {
                Console.WriteLine(user.Key);
                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }

        private static void AddUsers(Dictionary<string, Dictionary<string, int>> userTags)
        {
            while (true)
            {
                var commands = Console.ReadLine().Split(new string[] { " -> ", " " }, StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "end") break;
                if (commands[0] == "ban")
                {
                    userTags.Remove(commands[1]);
                    continue;
                }

                var username = commands[0];
                var tag = commands[1];
                var likes = int.Parse(commands[2]);

                if (userTags.ContainsKey(username) == false)
                {
                    userTags.Add(username, new Dictionary<string, int>());
                }

                if (userTags[username].ContainsKey(tag) == false)
                {
                    userTags[username].Add(tag, 0);
                }

                userTags[username][tag] += likes;
            }
        }
    }
}