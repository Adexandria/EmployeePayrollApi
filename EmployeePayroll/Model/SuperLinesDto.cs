using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class SuperLinesDto
    {
        public Guid SuperLinesId { get; set; }
        public string ContributionType { get; set; }
        public string CalculationType { get; set; }
        public double MininumMonthlyEarnings { get; set; } = 0.00;
        public int ExpenseAccountCode { get; set; } = 0;
        public int LiabilityAccountCode { get; set; } = 0;
    }
}
