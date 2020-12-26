using System;
using System.Collections.Generic;

namespace AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            var phrases = new List<string>
            {
                "Excellent product. ",
                "Such a great product. ",
                "I always use that product. ",
                "Best product of its category. ",
                "Exceptional product. ",
                "I can’t live without this product. "
            };

            var events = new List<string>
            {
                "Now I feel good. ",
                "I have succeeded with this product. ",
                "Makes miracles. I am happy of the results! ",
                "I cannot believe but now I feel awesome. ",
                "Try it yourself, I am very satisfied. ",
                "I feel great! "
            };

            var authors = new List<string>
            {
                "Diana - ",
                "Petya - ",
                "Stella - ",
                "Elena - ",
                "Katya - ",
                "Iva - ",
                "Annie - ",
                "Eva - "
            };

            var cities = new List<string>
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };


            int messagesCount = int.Parse(Console.ReadLine());
            var random = new Random();

            for (int i = 0; i < messagesCount; i++)
            {
                string message = string.Empty;
                int rand = random.Next(0, phrases.Count);
                message += phrases[rand];

                rand = random.Next(0, events.Count);
                message += events[rand];

                rand = random.Next(0, authors.Count);
                message += authors[rand];

                rand = random.Next(0, cities.Count);
                message += cities[rand];

                Console.WriteLine(message);
            }
        }
    }
}
