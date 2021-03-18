namespace ProductShop
{
    using ProductShop.Data;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            var result = GetProductsInRange(context);
            File.WriteAllText("../../../r.txt", result);
            Console.WriteLine(result);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(x => x.Price > 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    buyer = x.Buyer.FirstName + ' ' + x.Buyer.LastName
                })
                .OrderBy(x => x.price)
                .Take(10)
                .ToList();

            XDocument doc = new XDocument(); // document
            doc.Declaration = new XDeclaration("1.0", "UTF-8", null); // header
            doc.Add(new XElement("Products")); // root
            foreach (var product in products)
            {
                XElement el =
                    new XElement("Product", // parent
                        new XElement("name", product.name), // children
                        new XElement("price", product.price)); // children

                if (product.buyer != null)
                {
                    el.Add(new XElement("buyer", product.buyer));
                }

                doc.Root.Add(el);
            }

            var wr = new StringWriter();
            doc.Save(wr);
            return wr.ToString();
        }
    }
}