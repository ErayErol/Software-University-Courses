namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            string result = ImportSuppliers(context, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));
            SupplierInputModel[] supplierInputModel = serializer.Deserialize(new StringReader(inputXml)) as SupplierInputModel[];

            Supplier[] suppliers = supplierInputModel
                .Select(x => new Supplier
                {
                    Name = x.Name,
                    IsImporter = x.IsImporter,
                }).ToArray();

            context.AddRange(suppliers);
            context.SaveChanges();
            string result = $"Successfully imported {suppliers.Length}";
            return result;
        }
    }
}