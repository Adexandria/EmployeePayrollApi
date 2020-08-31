using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayroll.Entities
{
    public class DeductionLines
    {
        [Key]
        public Guid DeductionLinesId { get; set; }
        public CalculationType CalculationType { get; set; }
    }
}