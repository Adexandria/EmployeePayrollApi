using AutoMapper;
using EmployeePayroll.Entities;
using EmployeePayroll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.profiles
{
    public class LeaveBalancesProfile :Profile
    {
        public LeaveBalancesProfile()
        {
            CreateMap<LeaveBalances, LeaveBalancesDto>()
           .ForMember(dest => dest.TypeOfUnits, opt => opt.MapFrom(src => src.TypeOfUnits.ToString()));

        }
    }
}
