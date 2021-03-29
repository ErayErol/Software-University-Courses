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
            var result = CountCopiesByAuthor(db);
            Console.WriteLine(result);
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
