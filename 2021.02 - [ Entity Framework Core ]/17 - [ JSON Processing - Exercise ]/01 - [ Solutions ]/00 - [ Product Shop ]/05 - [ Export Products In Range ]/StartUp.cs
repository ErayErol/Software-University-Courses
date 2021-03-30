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
            var result = GetProductsInRange(context);
            Console.WriteLine(result);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Include(x=>x.Seller)
                .AsEnumerable()
                .Where(p => p.Price > 500 && p.Price <= 1000)
                .Select(p=>new
                {
                    p.Name,
                    p.Price,
                    Seller = p.Seller.FirstName + ' ' + p.Seller.LastName,
                })
                .OrderBy(p=>p.Price)
                .ToList();

            DefaultContractResolver contractResolver =
                new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
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