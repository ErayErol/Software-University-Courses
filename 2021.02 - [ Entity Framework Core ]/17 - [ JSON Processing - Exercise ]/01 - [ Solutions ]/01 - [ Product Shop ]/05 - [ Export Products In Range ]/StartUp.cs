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
        private const int PriceRangeFirstCriteria = 500;
        private const int PriceRangeSecondCriteria = 1000;

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
                .Include(x => x.Seller)
                .AsEnumerable()
                .Where(p => p.Price > PriceRangeFirstCriteria && p.Price <= PriceRangeSecondCriteria)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = p.Seller.FirstName + ' ' + p.Seller.LastName,
                })
                .OrderBy(p => p.Price)
                .ToList();

            var formatting = JsonSerializerSettings();
            var json = JsonConvert.SerializeObject(products, formatting);

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