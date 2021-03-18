namespace ProductShop
{
    using ProductShop.Data;
    using ProductShop.Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            var xml = File.ReadAllText("../../../Datasets/categories.xml");
            var result = ImportCategories(context, xml);
            Console.WriteLine(result);
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(type: typeof(Dtos.Import.Category[]), root: new XmlRootAttribute(elementName: "Categories"));
            Dtos.Import.Category[] deserialize = (Dtos.Import.Category[])serializer.Deserialize(textReader: new StringReader(s: inputXml));
            Models.Category[] categories = deserialize
                .Select(selector: x => new Category() {Name = x.Name})
                .Where(predicate: x => x.Name != null)
                .ToArray();

            // ReSharper disable once CoVariantArrayConversion
            context.AddRange(categories);
            context.SaveChanges();
            var result = $"Successfully imported {categories.Length}";
            return result;
        }
    }
}