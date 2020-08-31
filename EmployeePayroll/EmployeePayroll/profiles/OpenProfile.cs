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
                .ForMember(dest => dest.OpenBalancesId, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.LeaveLines.CalculationType, opt => opt.MapFrom(src => src.LeaveLines.CalculationType))
                .ForPath(dest => dest.LeaveLines.CalculationType, opt => opt.MapFrom(src => src.LeaveLines.CalculationType))
                .ForPath(dest => dest.LeaveLines.NumberofUnits, opt => opt.MapFrom(src => src.LeaveLines.NumberofUnits))
                .ForPath(dest => dest.LeaveLines.EntitlementFinalPayoutType, opt => opt.MapFrom(src => src.LeaveLines.EntitlementFinalPayoutType))
                .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => src.Tax))
                .ForMember(dest => dest.OpeningBalanceDate, opt => opt.MapFrom(src => src.OpeningBalanceDate));

            CreateMap<Employee, OpenUpdate>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OpenBalancesId));
            CreateMap<OpenBalances, OpenDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OpenBalancesId))
                .ForMember(dest => dest.LeaveLines, opt => opt.MapFrom(src => src.LeaveLines))
                   .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => src.Tax))
                   .ForMember(dest => dest.OpeningBalanceDate, opt => opt.MapFrom(src => src.OpeningBalanceDate));

            CreateMap<OpenDto, Employee>()
                .ForPath(dest => dest.OpenBalances.OpenBalancesId, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.OpenBalances.OpeningBalanceDate, opt => opt.MapFrom(src => src.OpeningBalanceDate))
                .ForPath(dest => dest.OpenBalances.LeaveLines.LeaveLinesId, opt => opt.MapFrom(src => src.LeaveLines.LeaveLinesId))
                .ForPath(dest => dest.OpenBalances.LeaveLines.NumberofUnits, opt => opt.MapFrom(src => src.LeaveLines.NumberofUnits))
                .ForPath(dest => dest.OpenBalances.LeaveLines.EntitlementFinalPayoutType, opt => opt.MapFrom(src => src.LeaveLines.EntitlementFinalPayoutType))
                .ForPath(dest => dest.OpenBalances.LeaveLines.CalculationType, opt => opt.MapFrom(src => src.LeaveLines.CalculationType))
                .ForPath(dest => dest.OpenBalances.Tax, opt => opt.MapFrom(src => src.Tax));
               

        }
    }
}
