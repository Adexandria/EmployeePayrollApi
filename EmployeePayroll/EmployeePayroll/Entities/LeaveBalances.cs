using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayroll.Entities
{
    public class LeaveBalances
    {
        [Key]
        public Guid LeaveBalancesId { get; set; }
        public string LeaveName { get; set; }
        public int NumberOfUnits { get; set; }
        public TypeOfUnits TypeOfUnits { get; set; }
    }
}