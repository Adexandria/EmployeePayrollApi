using EmployeePayroll.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class TemplatesCreation:PayLinesDto
    {
        [Required(ErrorMessage ="Enter Id")]
        public Guid Id { get; set; }
        public SuperMemberships SuperMemberships { get; set; }
        public LeaveBalances LeaveBalances { get; set; }
    }
}
