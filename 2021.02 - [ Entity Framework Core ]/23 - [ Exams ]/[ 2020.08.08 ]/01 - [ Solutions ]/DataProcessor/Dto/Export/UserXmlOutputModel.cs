using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("User")]
    public class UserXmlOutputModel
    {
        [XmlArray(ElementName = "Purchases")]
        public PurchaseXmlOutputModel[] Purchases { get; set; }
        [XmlElement(ElementName = "TotalSpent")]
        public decimal TotalSpent { get; set; }
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }

    }

    [XmlType("Purchase")]
    public class PurchaseXmlOutputModel
    {
        [XmlElement(ElementName = "Card")]
        public string Card { get; set; }
        [XmlElement(ElementName = "Cvc")]
        public string Cvc { get; set; }
        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }
        [XmlElement(ElementName = "Game")]
        public GameXmlOutputModel Game { get; set; }
    }

    [XmlType("Game")]
    public class GameXmlOutputModel
    {
        [XmlElement(ElementName = "Genre")]
        public string Genre { get; set; }
        [XmlElement(ElementName = "Price")]
        public decimal Price { get; set; }
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }
    }
}
