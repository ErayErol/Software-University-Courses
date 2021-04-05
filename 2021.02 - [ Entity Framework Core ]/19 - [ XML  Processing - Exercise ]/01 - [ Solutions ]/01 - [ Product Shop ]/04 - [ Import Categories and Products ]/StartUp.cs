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
            var xml = File.ReadAllText("../../../Datasets/categories-products.xml");
            var result = ImportCategoryProducts(context, xml);
            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categories = context.Categories.Select(x => x.Id).ToList();
            var products = context.Products.Select(x => x.Id).ToList();

            //var serializer = new XmlSerializer(typeof(CategoryProductInputModel[]), new XmlRootAttribute("CategoryProducts"));
            //CategoryProductInputModel[] deserialize = (CategoryProductInputModel[])serializer.Deserialize(new StringReader(inputXml));

            const string root = "CategoryProducts";
            CategoryProductInputModel[] categoryProductInputModels = XmlConverter.Deserializer<CategoryProductInputModel>(inputXml, root);

            CategoryProduct[] categoryProducts = categoryProductInputModels
                .Where(x => categories.Contains(x.CategoryId) && products.Contains(x.ProductId))
                .Select(x => new CategoryProduct()
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId
                })
                .ToArray();

            context.AddRange((CategoryProduct[])categoryProducts);
            context.SaveChanges();
            var result = $"Successfully imported {categoryProducts.Length}";
            return result;
        }
    }
}