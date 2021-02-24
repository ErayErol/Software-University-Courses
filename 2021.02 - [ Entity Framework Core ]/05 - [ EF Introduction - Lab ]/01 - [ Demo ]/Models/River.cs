using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.Models
{
    public partial class River
    {
        public River()
        {
            CountriesRivers = new HashSet<CountriesRiver>();
        }

        public int Id { get; set; }
        public string RiverName { get; set; }
        public int Length { get; set; }
        public int DrainageArea { get; set; }
        public int AverageDischarge { get; set; }
        public string Outflow { get; set; }

        public virtual ICollection<CountriesRiver> CountriesRivers { get; set; }
    }
}
