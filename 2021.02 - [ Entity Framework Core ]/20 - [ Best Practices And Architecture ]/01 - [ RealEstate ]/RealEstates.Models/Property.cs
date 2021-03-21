using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Models
{
    public class Property
    {
        public Property()
        {
            this.Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public int Size { get; set; }

        public int? YardSize { get; set; }

        public byte? Floor { get; set; }

        public byte? TotalFloors { get; set; }

        public int? Year { get; set; }

        /// <summary>
        /// The price is in EURO
        /// </summary>
        public int? Price { get; set; }

        public int DistrictId { get; set; }
        public virtual District District { get; set; }

        public int TypeId { get; set; }
        public virtual PropertyType Type { get; set; }

        public int BuildingTypeId { get; set; }
        public virtual BuildingType BuildingType { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

    }
}
