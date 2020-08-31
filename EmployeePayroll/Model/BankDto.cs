using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class BankDto
    {
        public Guid BankAccountId { get; set; }

        public string StatementText { get; set; }

        public string AccountNumber { get; set; }

        public bool Remainder { get; set; } = false;
    }
}
