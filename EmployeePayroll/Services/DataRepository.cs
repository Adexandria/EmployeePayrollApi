using EmployeePayroll.Entities;
using EmployeePayroll.Helpers;
using EmployeePayroll.Model;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task Add(Employee employee)
        {
            if (employee == null)
            {
                throw new NullReferenceException(nameof(employee));
            }
            CreateGuidId(employee);
            await db.Employee.AddAsync(employee);
            await Save();
        }
        private void CreateGuidId(Employee employee) 
        {
            employee.EmployeeId = Guid.NewGuid();      
            
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

        public async Task<Address> UpdateAddress(Address address, Guid employeeId)
        {
            var employee = await GetEmployee(employeeId);
            if(employee == null) 
            {
                throw new NullReferenceException(nameof(employee));
            }
            var currentAddress = await GetAddressAsync(address.HomeAddressId);
            if(currentAddress == null) 
            {
                throw new NullReferenceException(nameof(employee));
            }
            db.Entry(currentAddress).State = EntityState.Detached;
            db.Entry(address).State = EntityState.Modified;
            await Save();
            return address;
        }

        public async Task<Bank> UpdateBankDetails(Bank bank, Guid employeeId)
        {
            var employee = await GetEmployee(employeeId);
            if (employee == null)
            {
                throw new NullReferenceException(nameof(employee));
            }
            var currentbank = await GetAddressAsync(bank.BankAccountId);
            if (currentbank == null)
            {
                throw new NullReferenceException(nameof(employee));
            }
            db.Entry(currentbank).State = EntityState.Detached;
            db.Entry(bank).State = EntityState.Modified;
            await Save();
            return bank;
        }
        private async Task<Address> GetAddressAsync(Guid id)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(id));
            }
            return await db.Address.Where(s => s.HomeAddressId == id).FirstOrDefaultAsync();
        }
        private async Task<Bank> GetBankAsync(Guid id)
        {
            if (id == null)
            {
                throw new NullReferenceException(nameof(id));
            }
            return await db.Bank.Where(s => s.BankAccountId == id).FirstOrDefaultAsync();
        }
    }
}
