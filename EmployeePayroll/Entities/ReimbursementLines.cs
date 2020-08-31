using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePayroll.Entities
{
    public class ReimbursementLines
    {
        [Key]
        public Guid ReimbursementLinesId { get; set; }
    }
}