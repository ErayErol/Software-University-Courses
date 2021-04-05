namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    public class Category
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
