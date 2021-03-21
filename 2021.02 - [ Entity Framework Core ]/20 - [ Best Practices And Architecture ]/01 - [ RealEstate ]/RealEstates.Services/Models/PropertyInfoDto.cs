using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services.Models
{
    public class PropertyInfoDto
    {
        public string DistrictName { get; set; }

        public int Size { get; set; }

        public int Price { get; set; }

        public string PropertyType { get; set; }
        
        public string BuildingType { get; set; }
    }
}
