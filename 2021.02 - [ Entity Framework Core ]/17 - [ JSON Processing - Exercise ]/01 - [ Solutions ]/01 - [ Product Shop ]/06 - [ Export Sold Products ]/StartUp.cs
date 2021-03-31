namespace ProductShop
{
    using ProductShop.Data;

    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            var result = GetSoldProducts(context);
            Console.WriteLine(result);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Include(x => x.ProductsSold)
                .ThenInclude(x => x.Buyer)
                .Where(p => p.ProductsSold.Count > 0 && p.ProductsSold.Any(z => z.Buyer != null))
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

            var formatting = JsonSerializerSettings();
            var json = JsonConvert.SerializeObject(users, formatting);

            return json;
        }

        private static JsonSerializerSettings JsonSerializerSettings()
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver();
            contractResolver.NamingStrategy = new CamelCaseNamingStrategy();
            var formatting = new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
            };
            return formatting;
        }
    }
}