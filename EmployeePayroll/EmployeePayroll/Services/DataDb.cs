using EmployeePayroll.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.Services
{
    public class DataDb:DbContext
    {
        public DataDb(DbContextOptions<DataDb> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<OpenBalances> OpenBalances { get; set; }
        public DbSet<PayTemplates> PayTemplates { get; set; }
        public DbSet<SuperMemberships> SuperMemberships { get; set; }
        public DbSet<SuperLines> SuperLines { get; set; }
        public DbSet<ReimbursementLines> ReimbursementLines { get; set; }
        public DbSet<LeaveLines> LeaveLines { get; set; }
        public DbSet<LeaveBalances> LeaveBalances { get; set; }
        public DbSet<DeductionLines> DeductionLines { get; set; }
        public DbSet<EarningsLines> EarningsLines { get; set; }
        



    }
}
