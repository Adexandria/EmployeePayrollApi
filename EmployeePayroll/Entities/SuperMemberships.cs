using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayroll.Entities
{
    public class SuperMemberships
    {
        [Key]
        public Guid SuperMembershipsId { get; set; }
        public Guid SuperFundId { get; set; }
        public int EmployeeNumber { get; set; }
    }
}