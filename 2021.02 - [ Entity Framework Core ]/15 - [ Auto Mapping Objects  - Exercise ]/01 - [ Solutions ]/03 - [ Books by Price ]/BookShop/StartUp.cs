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
            var result = GetBooksByPrice(db);
            Console.WriteLine(result);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context
                .Books
                .AsEnumerable()
                .Where(b => b.Price > 40)
                .Select(b => new { b.Title, b.Price})
                .OrderByDescending(b => b.Price)
                .ToList();

            var sb = new StringBuilder();
            books.ForEach(book => sb.AppendLine($"{book.Title} - ${book.Price:F2}"));
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
