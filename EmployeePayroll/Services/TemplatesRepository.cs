using EmployeePayroll.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Services
{
    public class TemplatesRepository : ITemplates
    {
        private readonly DataDb db;


        public TemplatesRepository(DataDb db)
        {
            this.db = db;

        }
        public async Task<PayTemplates> GetPayTemplate(Guid Id)
        {
            if(Id== null)
            {
                throw new NullReferenceException(nameof(Id));
            }
            return await db.PayTemplates.Where(r => r.PayTemplateId == Id).Include(s=>s.DeductionLine)
                .Include(s=>s.EarningsLine).Include(s=>s.LeaveBalance)
                .Include(s=>s.LeaveLine)
                .Include(s=>s.SuperLine)
                .Include(s=>s.SuperMembership)
                .Include(s=>s.ReimbursementLine)
                .AsNoTracking().FirstOrDefaultAsync();
        }
        private async Task<EarningsLines>GetEarningsLineAsync(Guid id)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(id));
            }
            return await db.EarningsLines.Where(s => s.EarningsLineId == id).FirstOrDefaultAsync();
        }
        private async Task<LeaveBalances> GetLeaveBalanceAsync(Guid id)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(id));
            }
            return await db.LeaveBalances.Where(s => s.LeaveBalanceId == id).FirstOrDefaultAsync();
        }
        private async Task<SuperLines> GetSuperLineAsync(Guid id) 
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(id));
            }
            return await db.SuperLines.Where(s => s.SuperLineId == id).FirstOrDefaultAsync();
        }
        private async Task<LeaveLines> GetLeaveLineAsync(Guid id) 
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(id));
            }
            return await db.LeaveLines.Where(s => s.LeaveLineId == id).FirstOrDefaultAsync();
        }
        private async Task<ReimbursementLines> GetReimbursementLineAsync(Guid id) 
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(id));
            }
            return await db.ReimbursementLines.Where(s => s.ReimbursementLineId == id).FirstOrDefaultAsync();
        }
        private async Task<DeductionLines> GetDeductionLineAsync(Guid id)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(id));
            }
            return await db.DeductionLines.Where(s => s.DeductionLineId == id).FirstOrDefaultAsync();
        }
        private async Task<SuperMemberships> GetSuperMembershipAsync(Guid id) 
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(id));
            }
            return await db.SuperMemberships.Where(s => s.SuperMembershipId == id).FirstOrDefaultAsync();
        }
        public async Task<PayTemplates> Update(PayTemplates payTemplate,Guid id)
        {
            var currentPayTemplate = await GetPayTemplate(id);
            if (currentPayTemplate == null)
            {
                throw new NullReferenceException(nameof(currentPayTemplate));
            }
            else
            {
                db.Entry(currentPayTemplate).State = EntityState.Detached;
                db.Entry(payTemplate).State = EntityState.Modified;
                await Save();
            }
            return await GetPayTemplate(payTemplate.PayTemplateId);
        }

        public Task<int> Save()
        {
            return db.SaveChangesAsync();
        }

        public async Task<EarningsLines> UpdateEarningLine(EarningsLines earningsLine, Guid TemplateId)
        {
            var currentPayTemplate = await GetPayTemplate(TemplateId);
            if (currentPayTemplate == null)
            {
                throw new NullReferenceException(nameof(currentPayTemplate));
            }
            var currentearningLine = await GetEarningsLineAsync(earningsLine.EarningsLineId);
            if(currentearningLine == null) 
            {
                await db.EarningsLines.AddAsync(earningsLine);
            }
            else
            {
                db.Entry(currentearningLine).State = EntityState.Detached;
                db.Entry(earningsLine).State = EntityState.Modified;
                await Save();
            }
            return earningsLine;
        }

        public async Task<LeaveBalances> UpdateLeaveBalance(LeaveBalances leaveBalance, Guid TemplateId)
        {
            var currentPayTemplate = await GetPayTemplate(TemplateId);
            if (currentPayTemplate == null)
            {
                throw new NullReferenceException(nameof(currentPayTemplate));
            }
            var currentleaveBalance = await GetLeaveBalanceAsync(leaveBalance.LeaveBalanceId);
            if (currentleaveBalance == null)
            {
                leaveBalance.LeaveBalanceId = Guid.NewGuid();
                await db.LeaveBalances.AddAsync(leaveBalance);
            }
            else
            {
                db.Entry(currentleaveBalance).State = EntityState.Detached;
                db.Entry(leaveBalance).State = EntityState.Modified;
                await Save();
            }
            return leaveBalance;
        }

        public async Task<SuperLines> UpdateSuperLines(SuperLines superLine, Guid TemplateId)
        {
            var currentPayTemplate = await GetPayTemplate(TemplateId);
            if (currentPayTemplate == null)
            {
                throw new NullReferenceException(nameof(currentPayTemplate));
            }
            var currentsuperLine = await GetSuperLineAsync(superLine.SuperLineId);
            if (currentsuperLine == null)
            {
                superLine.SuperLineId = Guid.NewGuid();
                await db.SuperLines.AddAsync(superLine);
            }
            else
            {
                db.Entry(currentsuperLine).State = EntityState.Detached;
                db.Entry(superLine).State = EntityState.Modified;
                await Save();
            }
            return superLine;
        }

        public async Task<LeaveLines> UpdateLeaveLine(LeaveLines leaveLine, Guid TemplateId)
        {
            var currentPayTemplate = await GetPayTemplate(TemplateId);
            if (currentPayTemplate == null)
            {
                throw new NullReferenceException(nameof(currentPayTemplate));
            }
            var currentleaveLine = await GetLeaveLineAsync(leaveLine.LeaveLineId);
            if (currentleaveLine == null)
            {
                leaveLine.LeaveLineId = Guid.NewGuid();
                await db.LeaveLines.AddAsync(leaveLine);
            }
            else
            {
                db.Entry(currentleaveLine).State = EntityState.Detached;
                db.Entry(leaveLine).State = EntityState.Modified;
                await Save();
            }
            return leaveLine;
        }

        public async Task<DeductionLines> UpdateDeductionLine(DeductionLines deductionLine, Guid TemplateId)
        {
            var currentPayTemplate = await GetPayTemplate(TemplateId);
            if (currentPayTemplate == null)
            {
                throw new NullReferenceException(nameof(currentPayTemplate));
            }
            var currentdeductionLine = await GetDeductionLineAsync(deductionLine.DeductionLineId);
            if (currentdeductionLine == null)
            {
                deductionLine.DeductionLineId = Guid.NewGuid();
                await db.DeductionLines.AddAsync(deductionLine);
            }
            else
            {
                db.Entry(currentdeductionLine).State = EntityState.Detached;
                db.Entry(deductionLine).State = EntityState.Modified;
                await Save();
            }
            return deductionLine;
        }

        public async Task<ReimbursementLines> UpdateReimbursementLine(ReimbursementLines reimbursementLine, Guid TemplateId)
        {
            var currentPayTemplate = await GetPayTemplate(TemplateId);
            if (currentPayTemplate == null)
            {
                throw new NullReferenceException(nameof(currentPayTemplate));
            }
            var currentreimbursementLine = await GetReimbursementLineAsync(reimbursementLine.ReimbursementLineId);
            if (currentreimbursementLine == null)
            {
                reimbursementLine.ReimbursementLineId = Guid.NewGuid();
                await db.ReimbursementLines.AddAsync(reimbursementLine);
            }
            else
            {
                db.Entry(currentreimbursementLine).State = EntityState.Detached;
                db.Entry(reimbursementLine).State = EntityState.Modified;
                await Save();
            }
            return reimbursementLine;
        }

        public async Task<SuperMemberships> UpdateSuperMembership(SuperMemberships superMembership, Guid TemplateId)
        {
            var currentPayTemplate = await GetPayTemplate(TemplateId);
            if (currentPayTemplate == null)
            {
                throw new NullReferenceException(nameof(currentPayTemplate));
            }
            var currentsuperMembership = await GetSuperMembershipAsync(superMembership.SuperMembershipId);
            if (currentsuperMembership == null)
            {
                superMembership.SuperMembershipId = Guid.NewGuid();
                superMembership.SuperFundId = Guid.NewGuid();
                await db.SuperMemberships.AddAsync(superMembership);
            }
            else
            {
                db.Entry(currentsuperMembership).State = EntityState.Detached;
                db.Entry(superMembership).State = EntityState.Modified;
                await Save();
            }
            return superMembership;
        }

        public async Task<PayTemplates> GetEmployeePayTemplate(Guid employeeId)
        {
            return await db.Employee.Where(s => s.EmployeeId == employeeId).Select(s => s.PayTemplate).FirstOrDefaultAsync();
        }
    }
}
