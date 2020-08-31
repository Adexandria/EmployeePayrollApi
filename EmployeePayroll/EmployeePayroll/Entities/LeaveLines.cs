using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayroll.Entities
{
    public class LeaveLines
    {
        [Key]
        public Guid LeaveLinesId { get; set; }
        public CalculationType CalculationType { get; set; }
        public EntitlementFinalPayoutType EntitlementFinalPayoutType { get; set; }
        public string NumberofUnits { get; set; } 
    }
}