using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePayroll.Entities
{
    public class ReimbursementLines
    {
        [Key]
        public Guid ReimbursementLineId { get; set; }

        [ForeignKey("PayTemplateId")]
        public Guid PayTemplateId { get; set; }
    }
}