using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Employees
{
    public class RegisterEmployeeInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)] 
        public string Name { get; set; }

        public int Age { get; set; }

        public int PositionId { get; set; }

        public string PositionName { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Address { get; set; }
    }
}
