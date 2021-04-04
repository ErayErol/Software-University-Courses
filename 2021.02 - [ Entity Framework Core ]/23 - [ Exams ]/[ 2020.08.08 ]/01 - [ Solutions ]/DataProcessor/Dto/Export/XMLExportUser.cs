namespace VaporStore.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class XMLExportUser
    {
        [XmlArray(ElementName = "Purchases")]
        public XMLExportPurchase[] Purchases { get; set; }
        
        [XmlElement(ElementName = "TotalSpent")]
        public decimal TotalSpent { get; set; }
        
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }

    }

    [XmlType("Purchase")]
    public class XMLExportPurchase
    {
        [XmlElement(ElementName = "Card")]
        public string Card { get; set; }
        
        [XmlElement(ElementName = "Cvc")]
        public string Cvc { get; set; }
        
        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
        
        [XmlElement(ElementName = "Game")]
        public XMLExportGame Game { get; set; }
    }

    [XmlType("Game")]
    public class XMLExportGame
    {
        [XmlElement(ElementName = "Genre")]
        public string Genre { get; set; }
        
        [XmlElement(ElementName = "Price")]
        public decimal Price { get; set; }
        
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
    }
}
