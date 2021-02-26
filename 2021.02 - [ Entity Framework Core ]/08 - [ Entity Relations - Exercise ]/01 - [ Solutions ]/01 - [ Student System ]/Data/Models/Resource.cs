namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Url { get; set; }

        [EnumDataType(typeof(ResourceType))]
        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }

    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }
}
