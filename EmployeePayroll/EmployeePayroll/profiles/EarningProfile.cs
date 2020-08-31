using AutoMapper;
using EmployeePayroll.Entities;
using EmployeePayroll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.profiles
{
    public class EarningProfile :Profile
    {
        public EarningProfile()
        {
            CreateMap<EarningsLines, EarningDto>()
            .ForMember(dest => dest.CalculationType, opt => opt.MapFrom(src => src.CalculationType.ToString()));
             
        }
    }
}
