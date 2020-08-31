using EmployeePayroll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Services
{
    public interface ITemplates
    {
        PayTemplates Update(PayTemplates payTemplates);
        int Save();
      
    }
}
