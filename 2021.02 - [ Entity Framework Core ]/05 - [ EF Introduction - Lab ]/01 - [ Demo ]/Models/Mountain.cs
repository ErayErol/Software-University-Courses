using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.Models
{
    public partial class Mountain
    {
        public Mountain()
        {
            MountainsCountries = new HashSet<MountainsCountry>();
            Peaks = new HashSet<Peak>();
        }

        public int Id { get; set; }
        public string MountainRange { get; set; }

        public virtual ICollection<MountainsCountry> MountainsCountries { get; set; }
        public virtual ICollection<Peak> Peaks { get; set; }
    }
}
