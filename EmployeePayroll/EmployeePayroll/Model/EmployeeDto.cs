using EmployeePayroll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class EmployeeDto 
    {
        public Guid EmployeeId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Status { get; set; }
        public string JobTitle { get; set; }
        public string Phonenumber { get; set; }
        public string Homenumber { get; set; }
        public string IsAuthorizedToLeave { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public BankDto Bank { get; set; }
        public Address Address { get; set; }
        public TemDto PayTemplates { get; set; }
        public OpenDto OpenBalances { get; set; }
    }
}
