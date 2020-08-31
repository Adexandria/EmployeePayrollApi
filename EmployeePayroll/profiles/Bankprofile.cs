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
            CreateMap<BankCreation, Bank>()
                .ForMember(dest=>dest.BankAccountId,opt=>opt.MapFrom(src=>src.BankId))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.AccountNumber))
              
                .ForMember(dest => dest.StatementText, opt => opt.MapFrom(src => src.StatementText))
                .ForMember(dest => dest.Remainder, opt => opt.MapFrom(src => src.Remainder));
            CreateMap<Bank, BankCreation>()
               .ForMember(dest => dest.BankId, opt => opt.MapFrom(src => src.BankAccountId));
              
            CreateMap<Bank,BankDto>()
                .ForPath(dest => dest.BankAccountId, opt => opt.MapFrom(src => src.BankAccountId))
                .ForPath(dest => dest.StatementText, opt => opt.MapFrom(src => src.StatementText))
                .ForPath(dest => dest.Remainder, opt => opt.MapFrom(src => src.Remainder))
                .ForPath(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.AccountNumber)); 

        }
    }
}
