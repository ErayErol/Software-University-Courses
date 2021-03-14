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
            var result = GetTotalProfitByCategory(db);
            Console.WriteLine(result);
            //File.WriteAllText("../../../r.txt", result);
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
