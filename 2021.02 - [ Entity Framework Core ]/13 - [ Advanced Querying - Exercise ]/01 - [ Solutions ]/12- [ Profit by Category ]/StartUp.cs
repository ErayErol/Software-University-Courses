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
            var result = GetTotalProfitByCategory(db);
            Console.WriteLine(result);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            var sb = new StringBuilder();
            categories.ForEach(category => sb.AppendLine($"{category.Name} ${category.Profit:F2}"));
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
