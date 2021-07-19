using EmployeePayroll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Services
{
    public interface ITemplates
    {
        Task<PayTemplates> GetPayTemplate(Guid employeeId);
        Task<PayTemplates> Update(PayTemplates payTemplate,Guid id);
        Task<int> Save();

        Task<EarningsLines> UpdateEarningLine(EarningsLines earningsLine, Guid TemplateId);
        Task<LeaveBalances> UpdateLeaveBalance(LeaveBalances leaveBalance, Guid TemplateId);
        Task<SuperLines> UpdateSuperLines(SuperLines superLine, Guid TemplateId);
        Task<LeaveLines> UpdateLeaveLine(LeaveLines leaveLine, Guid TemplateId);
        Task<DeductionLines> UpdateDeductionLine(DeductionLines deductionLine, Guid TemplateId);
        Task<ReimbursementLines> UpdateReimbursementLine(ReimbursementLines reimbursementLine, Guid TemplateId);
        Task<SuperMemberships> UpdateSuperMembership(SuperMemberships superMembership, Guid TemplateId);
      
    }
}
