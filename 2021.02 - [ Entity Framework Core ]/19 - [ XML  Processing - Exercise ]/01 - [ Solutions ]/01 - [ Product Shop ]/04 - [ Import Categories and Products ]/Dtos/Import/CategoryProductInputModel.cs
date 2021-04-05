namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    public class CategoryProduct
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement("ProductId")]
        public int ProductId { get; set; }
    }
}
