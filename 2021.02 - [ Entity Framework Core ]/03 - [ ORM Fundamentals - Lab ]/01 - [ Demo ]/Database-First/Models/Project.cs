namespace Demo.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Project
    {
        public Project()
        {
            this.EmployeesProjects = new HashSet<EmployeesProject>();
        }

        public int ProjectId { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }

        public virtual ICollection<EmployeesProject> EmployeesProjects { get; set; }
    }
}
