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
            int lengthCheck = int.Parse(Console.ReadLine());
            var result = CountBooks(db, lengthCheck);
            Console.WriteLine(result);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
        }
    }
}
