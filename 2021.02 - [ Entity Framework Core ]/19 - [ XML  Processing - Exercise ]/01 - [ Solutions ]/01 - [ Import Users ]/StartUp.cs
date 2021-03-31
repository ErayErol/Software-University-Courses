namespace ProductShop
{
    using ProductShop.Utilities;

    using Data;
    using Dtos.Import;
    using Models;
    using System;
    using System.IO;
    using System.Linq;

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
            // Deserialize Xml with Xml.Serialization
            //var serializer = new XmlSerializer(typeof(UserInputModel[]), new XmlRootAttribute("Users"));
            //UserInputModel[] deserialize = (UserInputModel[])serializer.Deserialize(new StringReader(inputXml));

            // Deserialize Xml with XmlConverter from ProductShop.Utilities 
            const string root = "Users";
            UserInputModel[] userInputModels = XmlConverter.Deserializer<UserInputModel>(inputXml, root);
            User[] users = userInputModels
                .Select(x => new User
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x?.Age,
                }).ToArray();

            context.AddRange((User[])users);
            context.SaveChanges();
            var result = $"Successfully imported {users.Length}";
            return result;
        }
    }
}