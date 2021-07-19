using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePayroll.Entities
{
    public class EarningsLines
    {
        [Key]
        public Guid EarningsLineId { get; set; }
        public CalculationType CalculationType { get; set; }
        public double RatePerUnit { get; set; } = 0.0000;
        public double NormalNumberOfUnits { get; set; } = 0.00000;
        [ForeignKey("PayTemplateId")]
        public Guid PayTemplateId { get; set; }
    }
}