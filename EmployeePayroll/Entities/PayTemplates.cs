using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePayroll.Entities
{
    public class PayTemplates : PayLines
    {
        [Key]
        public Guid PayTemplateId { get; set; }
        public SuperMemberships SuperMembership { get; set; }
        public LeaveBalances LeaveBalance {get;set;}

    }
}