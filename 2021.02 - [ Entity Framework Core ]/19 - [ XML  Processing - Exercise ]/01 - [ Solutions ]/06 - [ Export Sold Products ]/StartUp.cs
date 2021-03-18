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
            var result = GetSoldProducts(context);
            File.WriteAllText("../../../r.txt", result);
            Console.WriteLine(result);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context
                .Users
                .Where(x => x.ProductsSold.Count > 0)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    SoldProducts = x.ProductsSold
                        .Select(ps => new
                        {
                            ps.Name,
                            ps.Price
                        })
                })
                .Take(5)
                .ToList();

            XDocument doc = new XDocument(); // document
            doc.Declaration = new XDeclaration("1.0", "UTF-8", null); // header
            doc.Add(new XElement("Users")); // root
            foreach (var product in products)
            {
                XElement el =
                    new XElement("User", // parent
                        new XElement("firstName", product.FirstName), // children
                        new XElement("lastName", product.LastName));

                XElement soldProductElement = new XElement("soldProducts");
                foreach (var soldProduct in product.SoldProducts)
                {
                    soldProductElement.Add(
                        new XElement("Product",
                            new XElement("name", soldProduct.Name),
                            new XElement("price", soldProduct.Price)));
                }
                el.Add(soldProductElement);

                doc.Root.Add(el);
            }

            var wr = new StringWriter();
            doc.Save(wr);
            return wr.ToString();
        }
    }
}