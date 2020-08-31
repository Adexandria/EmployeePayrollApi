using EmployeePayroll.Entities;
using EmployeePayroll.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Services
{
    public interface IData
    {
        public PageList<Employee> Employees(PageSizes sizes);
        public Task<Employee> GetEmployee(Guid EmployeeId);
        Task<Employee> Add(Employee employee);
        Task<int> Save();
        Employee Update(Employee employee);
        public Task<int> Delete(Guid EmployeeId);
    }
}
