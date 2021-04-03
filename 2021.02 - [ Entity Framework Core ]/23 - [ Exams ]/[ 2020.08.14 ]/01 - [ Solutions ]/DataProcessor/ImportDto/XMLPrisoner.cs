namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class XMLPrisoner
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}