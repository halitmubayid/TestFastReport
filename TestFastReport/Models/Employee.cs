using System;
using System.Collections.Generic;

#nullable disable

namespace TestFastReport.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNo { get; set; }
        public bool WorkStatus { get; set; }

        public virtual Section Section { get; set; }
    }
}
