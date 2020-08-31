using AutoMapper;
using EmployeePayroll.Entities;
using EmployeePayroll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll.profiles
{
    public class AddressProfile :Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressCreation,Address>().ForMember(dest => dest.HomeAddressId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Address1, opt => opt.MapFrom(src => src.Address1))
                .ForMember(dest => dest.Address2, opt => opt.MapFrom(src => src.Address2))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region));
         
            CreateMap<Address,Employee>()
                 .ForPath(dest => dest.HomeAddress.HomeAddressId, opt => opt.MapFrom(src => src.HomeAddressId))
                .ForPath(dest => dest.HomeAddress.Address1, opt => opt.MapFrom(src => src.Address1))
                .ForPath(dest => dest.HomeAddress.Address2, opt => opt.MapFrom(src => src.Address2))
                .ForPath(dest => dest.HomeAddress.City, opt => opt.MapFrom(src => src.City))
                .ForPath(dest => dest.HomeAddress.Region, opt => opt.MapFrom(src => src.Region))
                .ForPath(dest => dest.HomeAddress.Country, opt => opt.MapFrom(src => src.Country))
                .ForPath(dest => dest.HomeAddress.PostalCode, opt => opt.MapFrom(src => src.PostalCode));

        }
    }
}
