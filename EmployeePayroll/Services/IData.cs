using EmployeePayroll.Entities;
using EmployeePayroll.Helpers;
using System;
using System.Threading.Tasks;

namespace EmployeePayroll.Services
{
    public interface IData
    {
        public PageList<Employee> Employees(PageSizes sizes);
        public Task<Employee> GetEmployee(Guid EmployeeId);
        Task Add(Employee employee);
        Task<int> Save();
        Employee Update(Employee employee);
        public Task<int> Delete(Guid EmployeeId);

        public Task<Address> UpdateAddress(Address address,Guid employeeId);

        public Task<Bank> UpdateBankDetails(Bank bank,Guid employeeId);
    }
}
