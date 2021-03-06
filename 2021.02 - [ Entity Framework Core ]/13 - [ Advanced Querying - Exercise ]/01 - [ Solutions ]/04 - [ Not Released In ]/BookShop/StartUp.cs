using System;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            int year = int.Parse(Console.ReadLine());
            string result = GetBooksNotReleasedIn(db, year);
            Console.WriteLine(result);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context
                .Books
                .AsEnumerable()
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new { b.Title, b.BookId})
                .OrderBy(b => b.BookId)
                .ToList();

            var sb = new StringBuilder();
            books.ForEach(book => sb.AppendLine(book.Title));
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
