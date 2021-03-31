using System;
using System.ComponentModel;

namespace CarDealer.Dtos.Import
{
    using CarDealer.Models;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class CarInputModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArrayItem("partId", IsNullable = false)]
        public CarsCarPartId[] parts { get; set; }

        [Serializable()]
        [DesignerCategory("code")]
        [XmlType(AnonymousType = true)]
        public class CarsCarPartId
        {
            [XmlAttribute()]
            public byte id { get; set; }
        }
    }
}

// <Car>
// <make>Opel</make>
// <model>Omega</model>
// <TraveledDistance>176664996</TraveledDistance>
// <parts>
// <partId id="38"/>
// <partId id="102"/>
// <partId id="23"/>
// <partId id="116"/>
// <partId id="46"/>
// <partId id="68"/>
// <partId id="88"/>
// <partId id="104"/>
// <partId id="71"/>
// <partId id="32"/>
// <partId id="114"/>
// </parts>
// </Car>