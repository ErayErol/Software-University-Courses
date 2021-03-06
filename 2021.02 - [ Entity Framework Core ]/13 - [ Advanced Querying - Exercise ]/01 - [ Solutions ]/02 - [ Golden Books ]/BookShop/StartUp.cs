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
            var result = GetGoldenBooks(db);
            Console.WriteLine(result);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var titles = context
                .Books
                .AsEnumerable()
                .Where(b => b.EditionType == Enum.Parse<EditionType>("Gold") && b.Copies < 5000)
                .Select(b => new { b.Title, b.BookId })
                .OrderBy(b => b.BookId)
                .ToList();

            var sb = new StringBuilder();
            titles.ForEach(title => sb.AppendLine(title.Title));
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
