namespace ProductShop
{
    using ProductShop.Dtos.Import;
    using ProductShop.Utillities;

    using Data;
    using Models;
    using System;
    using System.IO;
    using System.Linq;

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
            //var serializer = new XmlSerializer(type: typeof(CategoryInputModel[]), root: new XmlRootAttribute(elementName: "Categories"));
            //CategoryInputModel[] deserialize = (CategoryInputModel[])serializer.Deserialize(textReader: new StringReader(s: inputXml));

            const string root = "Categories";
            CategoryInputModel[] categoryInputModels = XmlConverter.Deserializer<CategoryInputModel>(inputXml, root);

            Category[] categories = categoryInputModels
                .Select(selector: x => new Category { Name = x.Name })
                .Where(predicate: x => x.Name != null)
                .ToArray();

            context.AddRange((Category[])categories);
            context.SaveChanges();
            var result = $"Successfully imported {categories.Length}";
            return result;
        }
    }
}