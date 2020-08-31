using EmployeePayroll.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EmployeePayroll.Entities
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        [Required]
        public Title Title { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string MiddleName { get; set; } = null;
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        public DateTimeOffset DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Phonenumber { get; set; }
        public string Homenumber { get; set; } 
        [Required]
        public DateTimeOffset StartDate { get; set; }
        [Required]
        public DateTimeOffset UpdatedDate { get; set; } 
        [Required]
        public bool IsAuthorizedToLeave { get; set; }
        public Guid BankId { get; set; }
        public Guid AddressId { get; set; }
        public Guid OpenBalancesId { get; set; }
        public Guid TemplatesId { get; set; }
       
        public Address HomeAddress { get; set; }
        public Bank BankAccount { get; set; }
        public PayTemplates PayTemplates { get; set; }
        public OpenBalances OpenBalances { get; set; }
     
    }
}
