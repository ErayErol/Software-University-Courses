using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Properties = new HashSet<Property>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? Importance { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
