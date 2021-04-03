namespace SoftJail.DataProcessor.ImportDto
{
    using SoftJail.Data.Models.Enums;

    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Officer")]
    public class XMLOfficerPrisoner
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [XmlElement("Money")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        [XmlElement("Position")]
        [EnumDataType(typeof(Position))]
        [Required]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [EnumDataType(typeof(Weapon))]
        [Required]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public virtual XMLPrisoner[] Prisoners { get; set; } // When we have XmlArray then property have to be Array - not List or ICollection ....
    }
}