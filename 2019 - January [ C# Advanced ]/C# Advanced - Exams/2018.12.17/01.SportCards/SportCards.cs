namespace _01.SportCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SportCards
    {
        static void Main(string[] args)
        {
            var cards = new Dictionary<string, SortedDictionary<string, decimal>>();
            AddedCards(cards);
            Print(cards);
        }

        private static void Print(Dictionary<string, SortedDictionary<string, decimal>> cards)
        {
            foreach (var card in cards.OrderByDescending(x => x.Value.Keys.Count))
            {
                Console.WriteLine($"{card.Key}:");
                foreach (var sport in card.Value)
                {
                    Console.WriteLine($"  -{sport.Key} - {sport.Value:F2}");
                }
            }
        }

        private static void AddedCards(Dictionary<string, SortedDictionary<string, decimal>> cards)
        {
            while (true)
            {
                var commands = Console.ReadLine().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "end") break;
                if (commands.Length == 1)
                {
                    var checkCard = commands[0].Split();
                    if (cards.ContainsKey(checkCard[1]) == false)
                    {
                        Console.WriteLine($"{checkCard[1]} is not available!");
                        continue;
                    }

                    Console.WriteLine($"{checkCard[1]} is available!");
                    continue;
                }

                var card = commands[0];
                var sport = commands[1];
                var price = decimal.Parse(commands[2]);
                if (cards.ContainsKey(card) == false) cards.Add(card, new SortedDictionary<string, decimal>());
                if (cards[card].ContainsKey(sport) == false) cards[card].Add(sport, price);
                cards[card][sport] = price;
            }
        }
    }
}