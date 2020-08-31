using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class LeaveLineDto
    {
        public Guid LeaveLinesId { get; set; }
        public string CalculationType { get; set; }
        public string EntitlementFinalPayoutType { get; set; }
        public string NumberofUnits { get; set; } 
    }
}
