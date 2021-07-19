using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace EmployeePayroll.Entities
{
    public abstract class PayLines
    {
        public EarningsLines EarningsLine { get; set; }
        public DeductionLines DeductionLine { get; set; }
        public SuperLines SuperLine { get; set; }
        public  ReimbursementLines ReimbursementLine { get; set; }
        public  LeaveLines LeaveLine { get; set; }


    }
}
