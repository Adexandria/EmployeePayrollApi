using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayroll.Entities
{
    public class OpenBalances
    {
        [Key]
        public Guid OpenBalancesId { get; set; }
        public Guid LinesId { get; set; }
        public LeaveLines LeaveLines { get; set; }
        public DateTimeOffset OpeningBalanceDate { get; set; }
        public string Tax { get; set; }
     
    }
}