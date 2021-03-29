namespace BookShop
{
    using Data;

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            string date = Console.ReadLine();
            string result = GetBooksReleasedBefore(db, date);
            Console.WriteLine(result);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var datetime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture); ;

            var books = context
                .Books
                .AsEnumerable()
                .Where(b => b.ReleaseDate.Value < datetime)
                .Select(b => new { b.Title, b.EditionType, b.Price, b.ReleaseDate })
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            var sb = new StringBuilder();
            books.ForEach(book => sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}"));
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
