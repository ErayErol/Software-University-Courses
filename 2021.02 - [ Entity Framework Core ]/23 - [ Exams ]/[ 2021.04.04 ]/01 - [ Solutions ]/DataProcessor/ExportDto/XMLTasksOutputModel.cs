namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Task")]
    public class XMLTasksOutputModel
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        
        [XmlElement(ElementName = "Label")]
        public string Label { get; set; }
    }
}