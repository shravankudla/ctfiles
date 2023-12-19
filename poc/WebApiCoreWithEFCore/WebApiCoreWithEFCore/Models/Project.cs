using System;
using System.Collections.Generic;

namespace WebApiCoreWithEFCore.Models
{
    public partial class Project
    {
        public Project()
        {
            Employees = new HashSet<Employee>();
        }

        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
