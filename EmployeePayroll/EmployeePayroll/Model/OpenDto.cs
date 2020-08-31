using EmployeePayroll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class OpenDto
    {
        public Guid Id { get; set; }
        public LeaveLineDto LeaveLines { get; set; }
        public DateTimeOffset OpeningBalanceDate { get; set; }
        public string Tax { get; set; }
    }
}
