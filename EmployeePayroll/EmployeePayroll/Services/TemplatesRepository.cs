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
        private async Task<LeaveLines> GetLeaveId(Guid Id)
        {
            if (Id == null)
            {
                throw new NullReferenceException(nameof(Id));
            }
            return await db.LeaveLines
                .Where(r => r.LeaveLinesId == Id)
                .FirstOrDefaultAsync();
        }
        public async Task<PayTemplates> GetPay(Guid Id)
        {
            if(Id== null)
            {
                throw new NullReferenceException(nameof(Id));
            }
            return await db.PayTemplates.Where(r => r.PayTemplatesId == Id)
                .Include(r=>r.LeaveBalances)
                .Include(r=>r.ReimbursementLines)
                .Include(r=>r.SuperLines)
                .Include(r=>r.SuperMemberships)
                .Include(r=>r.EarningsLines)
                .Include(r=>r.DeductionLines).AsNoTracking().FirstOrDefaultAsync();
        }
        public PayTemplates Update(PayTemplates payTemplates)
        {
            payTemplates.Id = Guid.NewGuid();
            var query = db.PayTemplates.Attach(payTemplates);
            query.State = EntityState.Modified;
            return payTemplates;
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
