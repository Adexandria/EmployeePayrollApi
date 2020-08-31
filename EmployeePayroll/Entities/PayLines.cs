using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Entities
{
    public abstract class PayLines
    {
        public EarningsLines EarningsLines { get; set; }
        public DeductionLines DeductionLines { get; set; }
        public SuperLines SuperLines { get; set; }
        public ReimbursementLines ReimbursementLines { get; set; }
        public LeaveLines LeaveLines { get; set; }

    }
}
