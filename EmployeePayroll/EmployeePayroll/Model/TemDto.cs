using EmployeePayroll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class TemDto: PayLinesDto
    {
        public Guid Id { get; set; }
        public SuperMemberships SuperMemberships { get; set; }
        public LeaveBalancesDto LeaveBalances { get; set; }
    }
}
