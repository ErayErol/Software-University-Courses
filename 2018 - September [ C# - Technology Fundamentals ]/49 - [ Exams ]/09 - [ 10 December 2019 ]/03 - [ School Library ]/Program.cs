using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console
                .ReadLine()
                .Split("&", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            string bookName = string.Empty;
            string firstBook = string.Empty;
            string secondBook = string.Empty;
            int index = 0;

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] commands = input
                    .Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "Add Book":
                        bookName = commands[1];

                        AddingBook(books, bookName);
                        break;
                    case "Take Book":
                        bookName = commands[1];

                        TakingBook(books, bookName);
                        break;
                    case "Swap Books":
                        firstBook = commands[1];
                        secondBook = commands[2];

                        SwappingBook(books, firstBook, secondBook);
                        break;
                    case "Insert Book":
                        bookName = commands[1];

                        InsertingBook(books, bookName);
                        break;
                    case "Check Book":
                        index = int.Parse(commands[1]);

                        if ((index >= 0) && (index < books.Count))
                        {
                            CheckingBook(books, index);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", books));
        }
        static void AddingBook(List<string> books, string bookName)
        {
            if (!CheckingForBookExisting(books, bookName))
            {
                books.Insert(0, bookName);
            }
        }

        static void TakingBook(List<string> books, string bookName)
        {
            if (CheckingForBookExisting(books, bookName))
            {
                books.Remove(bookName);
            }
        }

        static void SwappingBook(List<string> books, string firstBook, string secondBook)
        {
            bool isFirstBookExisting = false;
            bool isSecondBookExisting = false;



            for (int i = 0; i < books.Count; i++)
            {
                if (firstBook == books[i] && isFirstBookExisting == false)
                {
                    isFirstBookExisting = true;
                }

                if (secondBook == books[i] && isSecondBookExisting == false)
                {
                    isSecondBookExisting = true;
                }
            }

            if (isFirstBookExisting && isSecondBookExisting)
            {
                int firstBookIndex = books.IndexOf(firstBook);
                int secondBookIndex = books.IndexOf(secondBook);
                string firstTemp = books[firstBookIndex];
                string secondTemp = books[secondBookIndex];

                books[firstBookIndex] = secondTemp;
                books[secondBookIndex] = firstTemp;
            }
        }

        static void InsertingBook(List<string> books, string bookName)
        {
            books.Add(bookName);
        }

        static void CheckingBook(List<string> books, int index)
        {
            Console.WriteLine(books[index]);
        }

        static bool CheckingForBookExisting(List<string> books, string bookName)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (bookName == books[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
