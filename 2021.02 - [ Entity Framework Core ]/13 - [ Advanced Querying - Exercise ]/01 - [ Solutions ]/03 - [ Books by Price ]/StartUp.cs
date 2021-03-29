namespace BookShop
{
    using Data;

    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        private const int MinPrice = 40;

        public static void Main()
        {
            using var db = new BookShopContext();
            var input = Console.ReadLine();
            var result = GetBooksByPrice(db, input);
            Console.WriteLine(result);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context
                .Books
                .AsEnumerable()
                .Where(b => b.Price > MinPrice)
                .Select(b => new { b.Title, b.BookId })
                .OrderByDescending(b => b.Price)
                .ToList();

            var sb = new StringBuilder();
            books.ForEach(book => sb.AppendLine($"{book.Title} - ${book.Price:F2}"));
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
