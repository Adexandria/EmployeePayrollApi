using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePayroll.Entities
{
    public class OpenBalances
    {
        [Key]
        public Guid OpenBalanceId { get; set; }
        public virtual LeaveLines LeaveLine { get; set; }
        public DateTimeOffset OpeningBalanceDate { get; set; }
        public string Tax { get; set; }
        [ForeignKey("EmployeeId")]
        public Guid EmployeeId { get; set; }

    }
}