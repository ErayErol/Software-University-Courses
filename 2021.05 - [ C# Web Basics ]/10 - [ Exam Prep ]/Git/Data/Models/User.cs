namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class User
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        //[MaxLength(DefaultMaxLength)]
        public string Password { get; set; }

        public virtual IEnumerable<Repository> Repositories { get; init; } = new HashSet<Repository>();

        public virtual IEnumerable<Commit> Commits { get; init; } = new HashSet<Commit>();
    }
}