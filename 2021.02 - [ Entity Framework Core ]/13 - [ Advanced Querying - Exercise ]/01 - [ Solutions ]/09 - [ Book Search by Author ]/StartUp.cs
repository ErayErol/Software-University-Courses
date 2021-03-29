namespace BookShop
{
    using Data;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            string input = Console.ReadLine();
            string result = GetBookTitlesContaining(db, input);
            Console.WriteLine(result);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books
                .AsEnumerable()
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new { b.Title,})
                .OrderBy(b => b.Title)
                .ToList();

            var sb = new StringBuilder();
            books.ForEach(book => sb.AppendLine(book.Title));
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
