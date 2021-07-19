using AutoMapper;
using EmployeePayroll.Entities;
using EmployeePayroll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.profiles
{
    public class TemplateProfile :Profile
    {
        public TemplateProfile()
        {
            CreateMap<TemplatesCreation, PayTemplates>()
                  .ForMember(dest => dest.PayTemplateId, opt => opt.MapFrom(src => src.Id));
            
            CreateMap<PayTemplates, TemDto>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PayTemplateId));
                  
           
        }
    }
}
