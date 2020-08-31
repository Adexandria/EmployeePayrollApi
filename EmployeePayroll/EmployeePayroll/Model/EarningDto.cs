using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Model
{
    public class EarningDto
    {
        public Guid EarningsLinesId { get; set; }
        public string CalculationType { get; set; }
        public double RatePerUnit { get; set; } = 0.0000;
        public double NormalNumberOfUnits { get; set; } = 0.00000;
    }
}
