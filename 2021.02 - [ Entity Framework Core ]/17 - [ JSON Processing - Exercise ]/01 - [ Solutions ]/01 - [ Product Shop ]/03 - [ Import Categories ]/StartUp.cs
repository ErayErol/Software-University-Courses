namespace ProductShop
{
    using ProductShop.Data;
    using ProductShop.Models;

    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            var json = File.ReadAllText("../../../Datasets/categories.json");
            var result = ImportCategories(context, json);
            Console.WriteLine(result);
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert
                .DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null)
                .ToArray();

            context.AddRange((Category[])categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
    }
}