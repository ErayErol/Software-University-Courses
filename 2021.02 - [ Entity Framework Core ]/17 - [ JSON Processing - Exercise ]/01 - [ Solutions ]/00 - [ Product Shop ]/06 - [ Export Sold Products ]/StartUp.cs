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
            var result = GetSoldProducts(context);
            //File.AppendAllText("../../../r.txt", result);
            Console.WriteLine(result);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context
                .Users
                .Include(x => x.ProductsSold)
                .ThenInclude(x => x.Buyer)
                .Where(p => p.ProductsSold.Count > 0 && p.ProductsSold.Any(z=>z.Buyer != null))
                .Select(p => new
                {
                    p.FirstName,
                    p.LastName,
                    SoldProducts = p.ProductsSold
                        .Select(x => new
                        {
                            x.Name,
                            x.Price,
                            BuyerFirstName = x.Buyer.FirstName,
                            BuyerLastName = x.Buyer.LastName,
                        })
                        .ToList()
                })
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
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