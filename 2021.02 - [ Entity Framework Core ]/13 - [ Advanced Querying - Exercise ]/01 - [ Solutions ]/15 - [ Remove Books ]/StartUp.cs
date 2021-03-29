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
        private const int CopiesCount = 4_200;

        public static void Main()
        {
            using var db = new BookShopContext();
            var result = RemoveBooks(db);
            Console.WriteLine(result);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Copies < CopiesCount)
                .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();
            return books.Count;
        }
    }
}