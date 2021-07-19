using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePayroll.Entities
{
    public class Bank
    {
        [Key]
        public Guid BankAccountId { get; set; }
        
        public string StatementText { get; set; }
     
        public string AccountNumber { get; set; }
    
        public bool Remainder { get; set; } = false;
        [ForeignKey("EmployeeId")]
        public Guid EmployeeId { get; set; }
    }
}