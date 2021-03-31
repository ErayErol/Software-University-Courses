namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.Dtos.Export;

    using System;
    using System.IO;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            string result = GetCarsWithDistance(context);
            Console.WriteLine(result);
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new CarOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarOutputModel[]), new XmlRootAttribute("cars"));
            var textWriter = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(textWriter, cars, ns);
            var result = textWriter.ToString();
            return result;

            //XDocument doc = new XDocument();
            //doc.Declaration = new XDeclaration("1.0", "UTF-8", null);
            //doc.Add(new XElement("cars"));
            //foreach (var car in cars)
            //{
            //    XElement el =
            //        new XElement("car", // parent
            //            new XElement("make", car.Make), // children
            //            new XElement("model", car.Model), // children
            //            new XElement("travelled-distance", car.TravelledDistance)); // children

            //    doc.Root.Add(el);
            //}

            //var wr = new StringWriter();
            //doc.Save(wr);
            //return wr.ToString();
        }
    }
}