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
            var result = GetCategoriesByProductsCount(context);
            File.WriteAllText("../../../r.txt", result);
            Console.WriteLine(result);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(x => new
                {
                    x.Name,
                    Count = x.CategoryProducts.Count(s=>s.CategoryId == x.Id),
                    AvgPrice = x.CategoryProducts.Where(s => s.CategoryId == x.Id).Average(s=>s.Product.Price),
                    Total = x.CategoryProducts.Where(s => s.CategoryId == x.Id).Sum(s=>s.Product.Price),

                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Total)
                .ToList();

            XDocument doc = new XDocument();
            doc.Declaration = new XDeclaration("1.0", "UTF-8", null);
            doc.Add(new XElement("Categories"));
            foreach (var category in categories)
            {
                XElement el =
                    new XElement("Category",
                        new XElement("name", category.Name),
                        new XElement("count", category.Count),
                        new XElement("averagePrice", category.AvgPrice),
                        new XElement("totalRevenue", category.Total));

                doc.Root.Add(el);
            }

            var wr = new StringWriter();
            doc.Save(wr);
            return wr.ToString();
        }
    }
}