using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class BankCreation
    {
        public Guid BankId { get; set; }
        [Required(ErrorMessage ="Enter statementText")]
        [StringLength(20)]
        public string StatementText { get; set; }
        [Required(ErrorMessage = "Enter account number")]
        [StringLength(20)]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "True/false")]
        public bool Remainder { get; set; } = false;
    }
}
