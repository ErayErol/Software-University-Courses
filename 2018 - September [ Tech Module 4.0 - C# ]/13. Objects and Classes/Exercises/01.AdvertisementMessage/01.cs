using System;

namespace _01.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            string[] events = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] authors = new string[]
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };

            string[] cities = new string[]
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Random rd = new Random();

                string randomPhrases = phrases[rd.Next(phrases.Length)];
                string randomEvents = events[rd.Next(events.Length)];
                string randomAuthors = authors[rd.Next(authors.Length)];
                string randomCities = cities[rd.Next(cities.Length)];

                Console.WriteLine($"{randomPhrases} {randomEvents} {randomAuthors} – {randomCities}");
            }
        }
    }
}