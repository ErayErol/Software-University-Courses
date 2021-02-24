using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.Models
{
    public partial class Peak
    {
        public int Id { get; set; }
        public string PeakName { get; set; }
        public int Elevation { get; set; }
        public int MountainId { get; set; }

        public virtual Mountain Mountain { get; set; }
    }
}
