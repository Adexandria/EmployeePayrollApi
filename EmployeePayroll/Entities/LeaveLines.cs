using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePayroll.Entities
{
    public class LeaveLines
    {
        [Key]
        public Guid LeaveLineId { get; set; }
        public CalculationType CalculationType { get; set; }
        public EntitlementFinalPayoutType EntitlementFinalPayoutType { get; set; }
        public string NumberofUnits { get; set; }
        [ForeignKey("OpenbalanceId")]
        public Guid OpenbalanceId { get; set; }
        [ForeignKey("PayTemplateId")]
        public Guid PayTemplateId { get; set; }
    }
}