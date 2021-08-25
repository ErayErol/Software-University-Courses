namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Repository
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(RepositoryNameMaxLength)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; init; } = DateTime.UtcNow;

        public bool IsPublic { get; set; }

        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public HashSet<Commit> Commits { get; init; } = new HashSet<Commit>();
    }
}