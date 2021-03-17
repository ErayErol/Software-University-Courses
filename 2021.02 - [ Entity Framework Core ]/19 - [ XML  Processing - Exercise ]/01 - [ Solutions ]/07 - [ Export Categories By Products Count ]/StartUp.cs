using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            var result = GetCategoriesByProductsCount(context);
            //File.AppendAllText("../../../r.txt", result);
            Console.WriteLine(result);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var products = context
                .Categories
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2"),
                })
                .OrderByDescending(x => x.ProductsCount)
                .ToList();

            DefaultContractResolver contractResolver =
                new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };

            var json = JsonConvert.SerializeObject(products, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return json;
        }

    }
}