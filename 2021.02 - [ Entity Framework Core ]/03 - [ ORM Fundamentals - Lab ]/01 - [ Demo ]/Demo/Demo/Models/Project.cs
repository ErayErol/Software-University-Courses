using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.Models
{
    public partial class Project
    {
        public Project()
        {
            EmployeesProjects = new HashSet<EmployeesProject>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<EmployeesProject> EmployeesProjects { get; set; }
    }
}
