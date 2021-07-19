using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePayroll.Entities
{
    public class LeaveBalances
    {
        [Key]
        public Guid LeaveBalanceId { get; set; }
        public string LeaveName { get; set; }
        public int NumberOfUnits { get; set; }
        public TypeOfUnits TypeOfUnits { get; set; }
        [ForeignKey("PayTemplateId")]
        public Guid PayTemplateId { get; set; }
    }
}