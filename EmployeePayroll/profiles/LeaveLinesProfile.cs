using AutoMapper;
using EmployeePayroll.Entities;
using EmployeePayroll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.profiles
{
    public class LeaveLinesProfile:Profile
    {
        public LeaveLinesProfile()
        {
            CreateMap<LeaveLines, LeaveLineDto>()
                .ForMember(dest => dest.CalculationType, opt => opt.MapFrom(src => src.CalculationType.ToString()))
                  .ForMember(dest => dest.EntitlementFinalPayoutType, opt => opt.MapFrom(src => src.EntitlementFinalPayoutType.ToString()))
                  .ForMember(dest => dest.NumberofUnits, opt => opt.MapFrom(src => src.NumberofUnits));
        }
    }
}
