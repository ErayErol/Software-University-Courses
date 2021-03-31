namespace ProductShop
{
    using ProductShop.Data;
    using ProductShop.Models;

    using Newtonsoft.Json;
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            var json = File.ReadAllText("../../../Datasets/products.json");
            var result = ImportProducts(context, json);
            Console.WriteLine(result);
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson);
            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
    }
}