using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseXmlModel
    {
        // •	Type – enumeration of type PurchaseType, with possible values (“Retail”, “Digital”) (required) 
        // •	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits, separated by dashes (ex. “ABCD-EFGH-1J3L”) (required)
        // •	Date – Date (required)
        // •	Card – the purchase’s card (required)

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }

        [Required]
        [XmlElement("Key")]
        [RegularExpression(@"[\S]{4}-[\S]{4}-[\S]{4}")]
        public string ProductKey { get; set; }

        [Required]
        [XmlElement("Card")]
        [RegularExpression(@"[\d]{4} [\d]{4} [\d]{4} [\d]{4}")]
        public string Card { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }
    }
}

// <Purchase title="Dungeon Warfare 2">
// <Type>Digital</Type>
// <Key>ZTZ3-0D2S-G4TJ</Key>
// <Card>1833 5024 0553 6211</Card>
// <Date>07/12/2016 05:49</Date>
// </Purchase>
// 