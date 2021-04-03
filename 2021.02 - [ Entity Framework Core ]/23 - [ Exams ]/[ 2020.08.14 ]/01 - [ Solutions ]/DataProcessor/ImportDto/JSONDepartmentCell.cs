namespace SoftJail.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class JSONDepartmentCell
    {
        public JSONDepartmentCell()
        {
            this.Cells = new HashSet<JSONCell>();
        }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }
        
        public ICollection<JSONCell> Cells { get; set; }
    }
}