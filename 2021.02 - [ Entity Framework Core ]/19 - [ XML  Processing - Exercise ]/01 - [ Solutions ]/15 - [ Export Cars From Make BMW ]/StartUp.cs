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
            string result = GetCarsFromMakeBmw(context);
            //File.WriteAllText("../../../r.txt", result);
            Console.WriteLine(result);
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance

                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x=>x.TravelledDistance)
                .ToList();

            XDocument doc = new XDocument();
            doc.Declaration = new XDeclaration("1.0", "UTF-8", null);
            doc.Add(new XElement("cars"));
            foreach (var car in cars)
            {
                XElement el =
                    new XElement("car", // parent
                        new XAttribute("id", car.Id), // children
                        new XAttribute("model", car.Model), // children
                        new XAttribute("travelled-distance", car.TravelledDistance)); // children

                doc.Root.Add(el);
            }

            var wr = new StringWriter();
            doc.Save(wr);
            return wr.ToString();
        }
    }
}