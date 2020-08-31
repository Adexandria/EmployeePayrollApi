using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayroll.Entities
{
    public class PayTemplates:PayLines
    {
        [Key]
        public Guid PayTemplatesId { get; set; }
        public Guid Id { get; set; }
        public SuperMemberships SuperMemberships { get; set; }
        public LeaveBalances LeaveBalances { get; set; }
    }
}