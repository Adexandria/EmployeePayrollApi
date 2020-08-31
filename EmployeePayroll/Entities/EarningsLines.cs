using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayroll.Entities
{
    public class EarningsLines
    {
        [Key]
        public Guid EarningsLinesId { get; set; }
        public CalculationType CalculationType { get; set; }
        public double RatePerUnit { get; set; } = 0.0000;
        public double NormalNumberOfUnits { get; set; } = 0.00000;

    }
}