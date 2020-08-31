using AutoMapper;
using EmployeePayroll.Entities;
using EmployeePayroll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.profiles
{
    public class SuperLineProfile:Profile
    {
        public SuperLineProfile()
        {
            CreateMap<SuperLines, SuperLinesDto>()
              .ForMember(dest => dest.CalculationType, opt => opt.MapFrom(src => src.CalculationType.ToString()))
                .ForMember(dest => dest.ContributionType, opt => opt.MapFrom(src => src.ContributionType.ToString()));
        }
    }
}
