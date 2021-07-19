using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeePayroll.Entities
{
    public class DeductionLines
    {
        [Key]
        public Guid DeductionLineId { get; set; }
        public CalculationType CalculationType { get; set; }
        [ForeignKey("PayTemplateId")]
        public Guid PayTemplateId { get; set; }
    }
}