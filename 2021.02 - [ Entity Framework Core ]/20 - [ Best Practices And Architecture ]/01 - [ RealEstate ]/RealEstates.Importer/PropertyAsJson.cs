using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Importer
{
    public class PropertyAsJson
    {
        public string Url { get; set; }
        
        public int Size { get; set; }

        public int YardSize { get; set; }
        
        public int Floor { get; set; }

        public int TotalFloors { get; set; }
        
        public string District { get; set; }
        
        public int Year { get; set; }
        
        public string Type { get; set; }

        public string BuildingType { get; set; }

        public int Price { get; set; }
    }
}
