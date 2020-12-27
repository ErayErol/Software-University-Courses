using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ").ToList();

            string title = input[0];
            string content = input[1];
            string author = input[2];

            Article article = new Article(title, content, author);

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                List<string> currentCommand = Console.ReadLine().Split(": ").ToList();

                string newValue = currentCommand[1];

                switch (currentCommand[0])
                {
                    case "Edit":
                        article.Edit(newValue);
                        break;
                    case "ChangeAuthor":
                        article.ChanceAuthor(newValue);
                        break;
                    case "Rename":
                        article.Rename(newValue);
                        break;
                }
            }

            article.Print(article);
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

        public void Edit(string newValue)
        {
            Content = newValue;
        }

        public void ChanceAuthor(string newValue)
        {
            Author = newValue;
        }

        public void Rename(string newValue)
        {
            Title = newValue;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

        public void Print(Article article)
        {
            Console.WriteLine(article);
        }
    }
}