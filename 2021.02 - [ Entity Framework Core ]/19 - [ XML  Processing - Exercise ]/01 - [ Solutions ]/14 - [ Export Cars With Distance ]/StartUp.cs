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
            string result = GetCarsWithDistance(context);
            //File.WriteAllText("../../../r.txt", result);
            Console.WriteLine(result);
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new
                {
                    x.Make,
                    x.Model,
                    x.TravelledDistance

                })
                .OrderBy(x => x.Make)
                .ThenBy(x=>x.Model)
                .Take(10)
                .ToList();

            XDocument doc = new XDocument();
            doc.Declaration = new XDeclaration("1.0", "UTF-8", null);
            doc.Add(new XElement("cars"));
            foreach (var car in cars)
            {
                XElement el =
                    new XElement("car", // parent
                        new XElement("make", car.Make), // children
                        new XElement("model", car.Model), // children
                        new XElement("travelled-distance", car.TravelledDistance)); // children

                doc.Root.Add(el);
            }

            var wr = new StringWriter();
            doc.Save(wr);
            return wr.ToString();
        }
    }
}