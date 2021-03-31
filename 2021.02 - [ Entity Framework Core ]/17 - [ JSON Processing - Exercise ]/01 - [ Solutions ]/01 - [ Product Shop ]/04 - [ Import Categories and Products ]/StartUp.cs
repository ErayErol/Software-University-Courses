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
            var json = File.ReadAllText("../../../Datasets/categories-products.json");
            var result = ImportCategoryProducts(context, json);
            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoriesProducts = JsonConvert
                .DeserializeObject<CategoryProduct[]>(inputJson);

            context.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }
    }
}