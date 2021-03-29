namespace BookShop
{
    using Data;

    using System;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        private const int MinCopiesCount = 5_000;

        public static void Main()
        {
            using var db = new BookShopContext();
            var input = Console.ReadLine();
            var result = GetGoldenBooks(db, input);
            Console.WriteLine(result);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var titles = context
                .Books
                .AsEnumerable()
                .Where(b => b.EditionType == Enum.Parse<EditionType>("Gold") && b.Copies < MinCopiesCount)
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
