using EmployeePayroll.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace EmployeePayroll.Services
{
    public class OpenRepository : IOpenBalance
    {
        private readonly DataDb db;


        public OpenRepository(DataDb db)
        {
            this.db = db;

        }
        
        public async Task<LeaveLines> GetLeaveLineAsync(Guid id)
        {
            return await db.LeaveLines
                .Where(r => r.LeaveLineId == id)
                .FirstOrDefaultAsync();
        }
      
      
       
        private async Task<OpenBalances> GetOpenBalance(Guid Id)
        {

            if (Id == null)
            {
                throw new NullReferenceException(nameof(Id));
            }
            
            return await db.OpenBalances.Where(r => r.OpenBalanceId == Id).Include(r=>r.LeaveLine).FirstOrDefaultAsync();
        }

        public async Task<OpenBalances> Update(OpenBalances openBalance,Guid id)
        {

            var currentOpenBalance = await GetOpenBalance(id);
            if (currentOpenBalance == null)
            {

                await db.OpenBalances.AddAsync(openBalance);
                await Save();
            }
            else
            {
                db.Entry(currentOpenBalance).State = EntityState.Detached;
                db.Entry(openBalance).State = EntityState.Modified;
                await Save();
            }
            return await GetOpenBalance(openBalance.OpenBalanceId);
        }
        public async Task<LeaveLines> UpdateLeaveLine(LeaveLines leaveLine, Guid openBalanceId)
        {
            var currentopenBalance = await GetOpenBalance(openBalanceId);
            if (currentopenBalance == null)
            {
                throw new NullReferenceException(nameof(currentopenBalance));
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
        public async Task<int> Save()
        {
            return await db.SaveChangesAsync();
        }
    }
}
