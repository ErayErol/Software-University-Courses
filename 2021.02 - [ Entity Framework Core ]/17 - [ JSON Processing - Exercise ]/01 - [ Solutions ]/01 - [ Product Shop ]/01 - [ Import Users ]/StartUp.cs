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
            var json = File.ReadAllText("../../../Datasets/users.json");
            var result = ImportUsers(context, json);
            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);
            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
    }
}