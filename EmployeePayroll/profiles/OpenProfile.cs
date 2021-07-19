using AutoMapper;
using EmployeePayroll.Entities;
using EmployeePayroll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.profiles
{
    public class OpenProfile:Profile
    {
        public OpenProfile()
        {
            CreateMap<OpenUpdate, OpenBalances>()
                .ForMember(dest => dest.OpenBalanceId, opt => opt.MapFrom(src => src.Id));
            
            CreateMap<OpenBalances, OpenDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OpenBalanceId));
               

        }
    }
}
