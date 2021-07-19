using EmployeePayroll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Services
{
    public interface IOpenBalance
    {
        Task<OpenBalances> Update(OpenBalances openBalance,Guid id);
        Task<LeaveLines> UpdateLeaveLine(LeaveLines leaveLine, Guid openBalanceId);
        Task<int> Save();
     
    }
}
