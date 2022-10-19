using System;
using System.Collections.Generic;

#nullable disable

namespace TestFastReport.Models
{
    public partial class EmployeeDTO
    {
        public string SectionData { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNo { get; set; }
        public bool WorkStatus { get; set; }
    }
}
