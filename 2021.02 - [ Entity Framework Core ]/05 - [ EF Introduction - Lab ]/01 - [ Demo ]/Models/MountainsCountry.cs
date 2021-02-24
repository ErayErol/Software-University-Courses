using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.Models
{
    public partial class MountainsCountry
    {
        public int MountainId { get; set; }
        public string CountryCode { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Mountain Mountain { get; set; }
    }
}
