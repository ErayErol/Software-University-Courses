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
            var result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var result = context
                .Users
                .AsEnumerable() // If you want to see the result => remove .AsEnumerable() => after that add it again for judge
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold
                            .Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(ps => new
                            {
                                ps.Name,
                                ps.Price
                            })
                            .ToList()
                    }
                })
                .ToList();

            var usersInfo = new
            {
                UsersCount = result.Count,
                Users = result
            };


            var formatting = JsonSerializerSettings();
            var json = JsonConvert.SerializeObject(usersInfo, formatting);

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