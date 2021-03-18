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
            var xml = File.ReadAllText("../../../Datasets/categories-products.xml");
            var result = ImportCategoryProducts(context, xml);
            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categories = context.Categories.Select(x => x.Id).ToList();
            var products = context.Products.Select(x => x.Id).ToList();

            var serializer = new XmlSerializer(typeof(Dtos.Import.CategoryProduct[]), new XmlRootAttribute("CategoryProducts"));
            Dtos.Import.CategoryProduct[] deserialize = (Dtos.Import.CategoryProduct[])serializer.Deserialize(new StringReader(inputXml));

            Models.CategoryProduct[] categoryProducts = deserialize
                .Where(x => categories.Contains(x.CategoryId) && products.Contains(x.ProductId))
                .Select(x => new CategoryProduct()
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId
                })
                .ToArray();

            // ReSharper disable once CoVariantArrayConversion
            context.AddRange(categoryProducts);
            context.SaveChanges();
            var result = $"Successfully imported {categoryProducts.Length}";
            return result;
        }
    }
}