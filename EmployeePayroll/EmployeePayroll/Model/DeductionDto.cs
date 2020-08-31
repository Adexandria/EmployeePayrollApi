using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class DeductionDto
    {
        public Guid DeductionLinesId { get; set; }
        public string CalculationType { get; set; }
    }
}
