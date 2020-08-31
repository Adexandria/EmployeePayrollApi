using EmployeePayroll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public abstract class PayLinesDto
    {
        public EarningDto EarningsLines { get; set; }
        public DeductionDto DeductionLines { get; set; }
        public SuperLinesDto SuperLines { get; set; }
        public ReimbursementLines ReimbursementLines { get; set; }
        public LeaveLineDto LeaveLines { get; set; }
       
        
    }
}
