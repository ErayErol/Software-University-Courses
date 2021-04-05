namespace CarDealer
{
    using CarDealer.Data;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            string result = GetLocalSuppliers(context);
            Console.WriteLine(result);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count(p => p.SupplierId == x.Id)
                })
                .ToList();

            XDocument doc = new XDocument();
            doc.Declaration = new XDeclaration("1.0", "UTF-8", null);
            doc.Add(new XElement("suppliers"));
            foreach (var supplier in suppliers)
            {
                XElement el =
                    new XElement("suplier",
                        new XAttribute("id", supplier.Id),
                        new XAttribute("name", supplier.Name),
                        new XAttribute("parts-count", supplier.PartsCount));

                doc.Root.Add(el);
            }

            var wr = new StringWriter();
            doc.Save(wr);
            return wr.ToString();
        }
    }
}