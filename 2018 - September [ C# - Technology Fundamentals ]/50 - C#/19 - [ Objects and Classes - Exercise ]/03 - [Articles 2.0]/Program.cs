using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Articles2
{
    class Program
    {
        static void Main(string[] args)
        {
            int articlesCount = int.Parse(Console.ReadLine());

            var list = new List<Article>();
            for (int i = 0; i < articlesCount; i++)
            {
                var commands = Console
                .ReadLine()
                .Split(", ")
                .ToList();

                string title = commands[0];
                string content = commands[1];
                string author = commands[2];

                Article article = new Article(title, content, author);

                list.Add(article);
            }

            string command = Console.ReadLine();

            if (command == "title")
            {
                list = list
                    .OrderBy(x => x.Title)
                    .ToList();
            }
            else if (command == "content")
            {
                list = list
                    .OrderBy(x => x.Content)
                    .ToList();
            }
            else if (command == "author")
            {
                list = list
                    .OrderBy(x => x.Author)
                    .ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, list.Select(x => $"{x.Title} - {x.Content}: {x.Author}")));
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
    }
}
