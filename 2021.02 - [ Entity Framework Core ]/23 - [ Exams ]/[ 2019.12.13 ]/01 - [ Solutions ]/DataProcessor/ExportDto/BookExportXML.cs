namespace BookShop.DataProcessor.ExportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Book")]
    public class BookExportXML
    {
        [XmlElement(ElementName = "Name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [XmlElement(ElementName = "Date")]
        [Required]
        public string Date { get; set; }
        
        [XmlAttribute(AttributeName = "Pages")]
        [Required]
        public string Pages { get; set; }
    }
}