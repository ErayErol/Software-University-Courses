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
            var input = Console.ReadLine();
            var result = GetBooksByAgeRestriction(db, input);
            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var titles = context
                .Books
                .AsEnumerable()
                .Where(b => b.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                .Select(b => new { b.Title})
                .OrderBy(b => b.Title)
                .ToList();

            var sb = new StringBuilder();
            titles.ForEach(title => sb.AppendLine(title.Title));
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
