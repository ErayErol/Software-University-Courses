using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.Models
{
    public partial class Country
    {
        public Country()
        {
            CountriesRivers = new HashSet<CountriesRiver>();
            MountainsCountries = new HashSet<MountainsCountry>();
        }

        public string CountryCode { get; set; }
        public string IsoCode { get; set; }
        public string CountryName { get; set; }
        public string CurrencyCode { get; set; }
        public string ContinentCode { get; set; }
        public int Population { get; set; }
        public int AreaInSqKm { get; set; }
        public string Capital { get; set; }

        public virtual Continent ContinentCodeNavigation { get; set; }
        public virtual Currency CurrencyCodeNavigation { get; set; }
        public virtual ICollection<CountriesRiver> CountriesRivers { get; set; }
        public virtual ICollection<MountainsCountry> MountainsCountries { get; set; }
    }
}
