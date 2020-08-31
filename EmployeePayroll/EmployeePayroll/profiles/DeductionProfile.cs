using AutoMapper;
using EmployeePayroll.Entities;
using EmployeePayroll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.profiles
{
    public class DeductionProfile :Profile
    {
        public DeductionProfile()
        {
            CreateMap<DeductionLines, DeductionDto>()
           .ForMember(dest => dest.CalculationType, opt => opt.MapFrom(src => src.CalculationType.ToString()));
        }
    }
}
