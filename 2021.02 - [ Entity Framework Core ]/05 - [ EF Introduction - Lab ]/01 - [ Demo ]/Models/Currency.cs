using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Countries = new HashSet<Country>();
        }

        public string CurrencyCode { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
