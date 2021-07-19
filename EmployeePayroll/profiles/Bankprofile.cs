using AutoMapper;
using EmployeePayroll.Entities;
using EmployeePayroll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EmployeePayroll.profiles
{
    public class Bankprofile:Profile
    {
        public Bankprofile()
        {
            CreateMap<BankCreation, Bank>();
       
            CreateMap<Bank, BankCreation>()
               .ForMember(dest => dest.BankId, opt => opt.MapFrom(src => src.BankAccountId));

            CreateMap<Bank, BankDto>();

        }
    }
}
