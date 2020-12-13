using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Article_2_0
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            var articles = new List<Article>();

            for (int i = 0; i < count; i++)
            {
                string[] commands = Console.ReadLine().Split(", ");

                string title = commands[0];
                string content = commands[1];
                string author = commands[2];

                var article = new Article(title, content, author);

                articles.Add(article);
            }

            string command = Console.ReadLine();

            PrintArticle(articles, command);
        }

        static void PrintArticle(List<Article> articles, string command)
        {
            switch (command)
            {
                case "title":
                    foreach (var article in articles.OrderBy(a => a.Title))
                    {
                        Console.WriteLine(article);
                    }
                    break;
                case "content":
                    foreach (var article in articles.OrderBy(a => a.Content))
                    {
                        Console.WriteLine(article);
                    }
                    break;
                case "author":
                    foreach (var article in articles.OrderBy(a => a.Author))
                    {
                        Console.WriteLine(article);
                    }
                    break;
            }
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

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}