using System;
using System.Collections.Generic;
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
            string input = Console.ReadLine();
            string result = GetBooksByCategory(db, input);
            Console.WriteLine(result);
        }

        public static string GetBooksByCategory(BookShopContext context, string inputCategories)
        {
            var categories = inputCategories.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var books = context
                .Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => new { b.Title})
                .OrderBy(b => b.Title)
                .ToList();

            var sb = new StringBuilder();
            books.ForEach(book => sb.AppendLine(book.Title));
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
