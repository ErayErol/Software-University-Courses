namespace TeisterMask.DataProcessor.ImportDto
{
    using TeisterMask.Data.Models.Enums;

    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Task")]
    public class XMLTaskInputModel
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [EnumDataType(typeof(ExecutionType))]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [EnumDataType(typeof(LabelType))]
        public int LabelType { get; set; }
    }
}