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
            CreateMap<AddressCreation, Address>().ForMember(dest => dest.HomeAddressId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
