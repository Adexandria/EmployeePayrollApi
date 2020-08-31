using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayroll.Entities
{
    public class SuperLines
    {
        [Key]
        public Guid SuperLinesId { get; set; }
        public ContributionType ContributionType { get; set; }
        public CalculationType CalculationType { get; set; }
        public double MininumMonthlyEarnings { get; set; } = 0.00;
        public int ExpenseAccountCode { get; set; } = 0;
        public int LiabilityAccountCode { get; set; } = 0;
    }
}