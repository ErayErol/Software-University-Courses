using System;
using System.Linq;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console
                .ReadLine()
                .Split(", ")
                .ToList();

            string title = input[0];
            string content = input[1];
            string author = input[2];

            int commandsCount = int.Parse(Console.ReadLine());

            Article article = new Article(title, content, author);

            for (int i = 0; i < commandsCount; i++)
            {
                var commands = Console
                .ReadLine()
                .Split(": ")
                .ToList();

                string command = commands[0];
                string newArg = commands[1];

                switch (command)
                {
                    case "Edit":
                        article.Edit(newArg);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(newArg);
                        break;
                    case "Rename":
                        article.Rename(newArg);
                        break;
                }
            }

            Console.WriteLine(article);
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

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
