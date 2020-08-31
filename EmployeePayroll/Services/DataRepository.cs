using EmployeePayroll.Entities;
using EmployeePayroll.Helpers;
using EmployeePayroll.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Services
{
    public class DataRepository : IData
    {
        private readonly DataDb db;
        private readonly IPropertyMappingService propertyMapping;

        public DataRepository(DataDb db,IPropertyMappingService propertyMapping)
        {
            this.db = db;
            this.propertyMapping = propertyMapping ?? throw new NullReferenceException(nameof(propertyMapping)); 
        }
        public PageList<Employee> Employees(PageSizes sizes)
        {
            var employees = db.Employee.OrderBy(r => r.EmployeeId);
            if (!string.IsNullOrWhiteSpace(sizes.Orderby))
                {
                var employee = propertyMapping.GetPropertyMapping<EmployeesDto, Employee>();
                employees = employees.ApplySort(sizes.Orderby,employee);
            }
            return PageList<Employee>.Create(employees, sizes.PageNumber, sizes.PageSize);
        }

        public async Task<Employee> Add(Employee employee)
        {
          
            if (employee == null)
            {
                throw new NullReferenceException(nameof(employee));
            }
            if(employee.BankAccount== null)
            {
                employee.BankAccount.BankAccountId = Guid.NewGuid();
            }
            
            employee.EmployeeId = Guid.NewGuid();      
            employee.AddressId = Guid.NewGuid();
            employee.OpenBalancesId = Guid.NewGuid();
            employee.TemplatesId = Guid.NewGuid();
            employee.LinesId = Guid.NewGuid();
            employee.Guid = Guid.NewGuid();
            employee.ReId = Guid.NewGuid();
            employee.SuperId = Guid.NewGuid();
            employee.MembershipId = Guid.NewGuid();
            employee.EarningId = Guid.NewGuid();
            employee.DeductionId = Guid.NewGuid();
            employee.BalanceId = Guid.NewGuid();
            await db.Employee.AddAsync(employee);
            return employee;
        }

        public async Task<int> Delete(Guid EmployeeId)
        {
            var query = await GetEmployee(EmployeeId);
            if(query == null)
            {
                throw new NullReferenceException(nameof(query));

            }
            db.Employee.Remove(query);
            return await db.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployee(Guid EmployeeId)
        {
            if (EmployeeId == null)
            {
                throw new NullReferenceException(nameof(EmployeeId));
            }
            return await db.Employee
                .Where(r => r.EmployeeId == EmployeeId)
                .Include(r => r.BankAccount)
                .Include(r => r.HomeAddress)
                .Include(r => r.OpenBalances)
                .Include(r => r.PayTemplates)
                .Include(r => r.OpenBalances).ThenInclude(r => r.LeaveLines)
                 .Include(r => r.PayTemplates).ThenInclude(r => r.DeductionLines)
                 .Include(r => r.PayTemplates).ThenInclude(r => r.LeaveBalances)
                 .Include(r => r.PayTemplates).ThenInclude(r => r.ReimbursementLines)
                 .Include(r => r.PayTemplates).ThenInclude(r => r.LeaveLines)
                 .Include(r => r.PayTemplates).ThenInclude(r => r.SuperLines)
                 .Include(r => r.PayTemplates).ThenInclude(r => r.SuperMemberships)
                 .Include(r => r.PayTemplates).ThenInclude(r => r.EarningsLines)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        public async Task<int> Save()
        {
            return await db.SaveChangesAsync();
        }

        public Employee Update(Employee employee)
        {
            var query = db.Employee.Attach(employee);
            query.State = EntityState.Modified;
            return employee;
        }

      
    }
}
