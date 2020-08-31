using EmployeePayroll.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        
        public async Task<LeaveLines> GetLeaveId(Guid id)
        {
            
            return await db.LeaveLines
                .Where(r => r.LeaveLinesId == id)
                .FirstOrDefaultAsync();
        }
      
      
       
        private async Task<OpenBalances> GetOpenBalances(Guid Id)
        {

            if (Id == null)
            {
                throw new NullReferenceException(nameof(Id));
            }
            
            return await db.OpenBalances.Where(r => r.OpenBalancesId == Id).Include(r=>r.LeaveLines).FirstOrDefaultAsync();
        }
        public OpenBalances Update(OpenBalances openBalances)
        {
            
            var query = db.OpenBalances.Attach(openBalances);
            query.State = EntityState.Modified;
            return openBalances;
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
