using System;
using System.Collections.Generic;

#nullable disable

namespace TestFastReport.Models
{
    public partial class Section
    {
        public Section()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Data { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
