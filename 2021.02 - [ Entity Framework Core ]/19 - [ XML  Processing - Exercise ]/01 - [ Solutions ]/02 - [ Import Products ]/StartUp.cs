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
            var xml = File.ReadAllText("../../../Datasets/products.xml");
            var result = ImportProducts(context, xml);
            Console.WriteLine(result);
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(Dtos.Import.Product[]), new XmlRootAttribute("Products"));
            Dtos.Import.Product[] deserialize = (Dtos.Import.Product[])serializer.Deserialize(new StringReader(inputXml));
            Models.Product[] products = deserialize
                .Select(x => new Product()
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerId = x.SellerId,
                    BuyerId = x?.BuyerId,
                }).ToArray();

            context.AddRange(products);
            context.SaveChanges();
            var result = $"Successfully imported {products.Length}";
            return result;
        }
    }
}