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
            //var lengthCheck = Console.ReadLine();
            var result = CountCopiesByAuthor(db);
            Console.WriteLine(result);
            //File.WriteAllText("../../../r.txt", result);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context
                .Authors
                .Include(a => a.Books)
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    BookCopiesCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BookCopiesCount)
                .ToList();

            var sb = new StringBuilder();
            authors.ForEach(author => sb.AppendLine($"{author.FullName} - {author.BookCopiesCount}"));
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
