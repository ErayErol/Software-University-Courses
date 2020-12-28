using System;
using System.Collections.Generic;
using System.Linq;

namespace WizardPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console
                .ReadLine()
                .Split(':')
                .ToList();

            List<string> newCards = new List<string>();

            string input;

            string cardName = string.Empty;
            string cardNameTwo = string.Empty;

            int index = 0;

            while ((input = Console.ReadLine()) != "Ready")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "Add":
                        cardName = commands[1];

                        AddingCard(cards, newCards, cardName);
                        break;
                    case "Insert":
                        cardName = commands[1];
                        index = int.Parse(commands[2]);

                        InsertingCard(cards, newCards, cardName, index);
                        break;
                    case "Remove":
                        cardName = commands[1];

                        RemovingCard(newCards, cardName);
                        break;
                    case "Swap":
                        cardName = commands[1];
                        cardNameTwo = commands[2];

                        SwappingCard(newCards, cardName, cardNameTwo);
                        break;
                    case "Shuffle":
                        ShufflingCard(newCards);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", newCards));
        }

        static void AddingCard(List<string> cards, List<string> newCards, string cardName)
        {
            if (cards.Contains(cardName))
            {
                newCards.Add(cardName);
            }
            else
            {
                Console.WriteLine("Card not found.");
            }
        }

        static void InsertingCard(List<string> cards, List<string> newCards, string cardName, int index)
        {
            if ((index >= 0 && index < newCards.Count) && (cards.Contains(cardName)))
            {
                newCards.Insert(index, cardName);
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }

        static void RemovingCard(List<string> newCards, string cardName)
        {
            if (newCards.Contains(cardName))
            {
                newCards.Remove(cardName);
            }
            else
            {
                Console.WriteLine("Card not found.");
            }
        }

        static void SwappingCard(List<string> newCards, string cardName, string cardNameTwo)
        {
            int firstIndex = newCards.IndexOf(cardName);
            int secondIndex = newCards.IndexOf(cardNameTwo);

            newCards[firstIndex] = cardNameTwo;
            newCards[secondIndex] = cardName;
        }

        static void ShufflingCard(List<string> newCards)
        {
            newCards.Reverse();
        }
    }
}
