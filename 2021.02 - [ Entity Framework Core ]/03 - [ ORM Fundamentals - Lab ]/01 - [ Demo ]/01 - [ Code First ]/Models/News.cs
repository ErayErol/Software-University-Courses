namespace Code_First.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        public News()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(300)]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
