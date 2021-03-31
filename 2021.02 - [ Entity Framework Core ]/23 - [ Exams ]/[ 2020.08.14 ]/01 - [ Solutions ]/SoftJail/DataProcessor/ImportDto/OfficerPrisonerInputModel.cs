using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerPrisonerInputModel
    {
        // •	Id – integer, Primary Key
        // •	FullName – text with min length 3 and max length 30 (required)
        // •	Salary – decimal (non-negative, minimum value: 0) (required)
        // •	Position - Position enumeration with possible values: “Overseer, Guard, Watcher, Labour” (required)
        // •	Weapon - Weapon enumeration with possible values: “Knife, FlashPulse, ChainRifle, Pistol, Sniper” (required)
        // •	DepartmentId - integer, foreign key (required)
        // •	Department – the officer's department (required)
        // •	OfficerPrisoners - collection of type OfficerPrisoner

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [XmlElement("Money")]
        public decimal Money { get; set; }

        [Required]
        [EnumDataType(typeof(Position))]
        [XmlElement("Position")]
        public string Position { get; set; }

        [Required]
        [EnumDataType(typeof(Weapon))]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [Required]
        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public virtual PrisonerInputModel[] Prisoners { get; set; } // When we have XmlArray then property have to be Array - not List or ICollection ....
    }

    [XmlType("Prisoner")]
    public class PrisonerInputModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }


}


// <Officer>
// <Name>Minerva Kitchingman</Name>
// <Money>2582</Money>
// <Position>Invalid</Position>
// <Weapon>ChainRifle</Weapon>
// <DepartmentId>2</DepartmentId>
// <Prisoners>
// <Prisoner id="15" />
// </Prisoners>
// </Officer>



