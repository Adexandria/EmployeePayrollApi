using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePayroll.Entities
{
    public class SuperMemberships
    {
        [Key]
        public Guid SuperMembershipId { get; set; }
        public Guid SuperFundId { get; set; }
        public int EmployeeNumber { get; set; }
        [ForeignKey("PayTemplateId")]
        public Guid PayTemplateId { get; set; }
    }
}