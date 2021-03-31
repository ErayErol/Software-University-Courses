namespace ProductShop
{
    using ProductShop.Data;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            var result = GetCategoriesByProductsCount(context);
            Console.WriteLine(result);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
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

            var formatting = JsonSerializerSettings();
            var json = JsonConvert.SerializeObject(categories, formatting);

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