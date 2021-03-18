namespace ProductShop
{
    using ProductShop.Dtos;
    using ProductShop.Data;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            var xml = File.ReadAllText("../../../Datasets/users.xml");
            var result = ImportUsers(context, xml);
            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Dtos.Import.User[]), new XmlRootAttribute("Users"));
            Dtos.Import.User[] deserialize = (Dtos.Import.User[])serializer.Deserialize(new StringReader(inputXml));
            Models.User[] users = deserialize
                .Select(x => new User()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x?.Age,
                }).ToArray();

            context.AddRange(users);
            context.SaveChanges();
            var result = $"Successfully imported {users.Length}";
            return result;
        }
    }
}