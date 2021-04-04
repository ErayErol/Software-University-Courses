namespace VaporStore.DataProcessor.Dto.Import
{
    using VaporStore.Data.Models.Enums;

    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class XMLPurchase
    {
        [XmlElement("Type")]
        [Required]
        [EnumDataType(typeof(PurchaseType))]
        public string Type { get; set; }

        [XmlElement("Key")]
        [Required]
        [RegularExpression(@"[\S]{4}-[\S]{4}-[\S]{4}")]
        public string ProductKey { get; set; }

        [XmlElement("Card")]
        [Required]
        [RegularExpression(@"[\d]{4} [\d]{4} [\d]{4} [\d]{4}")]
        public string Card { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }
    }
}