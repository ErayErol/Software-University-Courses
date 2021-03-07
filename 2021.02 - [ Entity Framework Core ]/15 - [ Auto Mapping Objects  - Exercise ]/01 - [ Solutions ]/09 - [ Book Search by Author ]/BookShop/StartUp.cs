using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using BookShop.Models;
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
            string result = GetBookTitlesContaining(db, input);
            Console.WriteLine(result);
            //File.WriteAllText("../../../r.txt", result);
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
