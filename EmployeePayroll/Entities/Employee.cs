using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayroll.Entities
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public Title Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Status Status { get; set; }
        public string JobTitle { get; set; }
        public string Phonenumber { get; set; }
        public string Homenumber { get; set; }
        public string IsAuthorizedToLeave { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public virtual OpenBalances OpenBalance { get; set; }
        public virtual PayTemplates PayTemplate { get; set; }
        public virtual Address HomeAddress {get;set;}
        public virtual Bank Bank { get; set; }

    }
}
