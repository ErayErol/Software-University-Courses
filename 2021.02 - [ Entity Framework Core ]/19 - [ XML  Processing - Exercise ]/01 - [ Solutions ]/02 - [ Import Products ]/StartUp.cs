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
            var xml = File.ReadAllText("../../../Datasets/products.xml");
            var result = ImportProducts(context, xml);
            Console.WriteLine(result);
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            //var serializer = new XmlSerializer(typeof(ProductInputModel[]), new XmlRootAttribute("Products"));
            //ProductInputModel[] deserialize = (ProductInputModel[])serializer.Deserialize(new StringReader(inputXml));

            const string root = "Products";
            ProductInputModel[] productInputModels = XmlConverter.Deserializer<ProductInputModel>(inputXml, root);
            Product[] products = productInputModels
                .Select(x => new Product()
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerId = x.SellerId,
                    BuyerId = x?.BuyerId,
                }).ToArray();

            context.AddRange((Product[])products);
            context.SaveChanges();
            var result = $"Successfully imported {products.Length}";
            return result;
        }
    }
}