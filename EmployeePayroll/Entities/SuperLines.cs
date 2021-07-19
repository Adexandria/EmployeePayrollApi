using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePayroll.Entities
{
    public class SuperLines
    {
        [Key]
        public Guid SuperLineId { get; set; }
        public ContributionType ContributionType { get; set; }
        public CalculationType CalculationType { get; set; }
        public double MininumMonthlyEarnings { get; set; } = 0.00;
        public int ExpenseAccountCode { get; set; } = 0;
        public int LiabilityAccountCode { get; set; } = 0;
        [ForeignKey("PayTemplateId")]
        public Guid PayTemplateId { get; set; }
    }
}