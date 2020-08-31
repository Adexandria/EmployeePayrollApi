using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class LeaveBalancesDto
    {
        public Guid LeaveBalancesId { get; set; }
        public string LeaveName { get; set; }
        public int NumberOfUnits { get; set; }
        public string TypeOfUnits { get; set; }
    }
}
