using AutoMapper;
using AutoMapper.Configuration.Conventions;
using EmployeePayroll.Entities;
using EmployeePayroll.Helpers;
using EmployeePayroll.Model;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EmployeePayroll.profiles
{
    public class EmployeeProfile :Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeesDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.MiddleName} {src.LastName}"))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => $"{src.Email }"))
                .ForMember(dest => dest.BankAccountId, opt => opt.MapFrom(src => src.BankId))
                .ForMember(dest => dest.Phonenumber, opt => opt.MapFrom(src => src.Phonenumber))
                .ForMember(dest => dest.Homenumber, opt => opt.MapFrom(src => src.Homenumber))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.IsAuthorizedToLeave, opt => opt.MapFrom(src => src.IsAuthorizedToLeave.ToString()));



            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.MiddleName} {src.LastName}"))
                 .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.ToString()))
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                 .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()))
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => $"{src.Email }"))
                 .ForMember(dest=>dest.Bank,opt=>opt.MapFrom(src=>src.BankAccount))
                 .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.HomeAddress))
                 .ForMember(dest => dest.OpenBalances, opt => opt.MapFrom(src => src.OpenBalances))
                 .ForMember(dest => dest.PayTemplates, opt => opt.MapFrom(src => src.PayTemplates))
                 .ForMember(dest => dest.Phonenumber, opt => opt.MapFrom(src => src.Phonenumber))
                 .ForMember(dest => dest.Homenumber, opt => opt.MapFrom(src => src.Homenumber))
                 .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                 .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
                 .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
                 .ForMember(dest => dest.IsAuthorizedToLeave, opt => opt.MapFrom(src => src.IsAuthorizedToLeave.ToString()));



            CreateMap<EmployeeCreation,Employee>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => $"{src.Email}"))
                .ForMember(dest => dest.Phonenumber, opt => opt.MapFrom(src => src.Phonenumber))
                .ForMember(dest => dest.Homenumber, opt => opt.MapFrom(src => src.Homenumber))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
                 .ForPath(dest => dest.PayTemplates.LeaveLines.LeaveLinesId, opt => opt.MapFrom(src => src.LinesId))
                 .ForPath(dest => dest.OpenBalances.LeaveLines.LeaveLinesId, opt => opt.MapFrom(src => src.LinesId))
                 .ForPath(dest => dest.PayTemplates.LeaveBalances.LeaveBalancesId, opt => opt.MapFrom(src => src.BalanceId))
                 .ForPath(dest => dest.PayTemplates.ReimbursementLines.ReimbursementLinesId, opt => opt.MapFrom(src => src.ReId))
                 .ForPath(dest => dest.PayTemplates.SuperMemberships.SuperFundId, opt => opt.MapFrom(src => src.Guid))
                 .ForPath(dest => dest.PayTemplates.SuperLines.SuperLinesId, opt => opt.MapFrom(src => src.SuperId))
                 .ForPath(dest => dest.PayTemplates.EarningsLines.EarningsLinesId, opt => opt.MapFrom(src => src.EarningId))
                 .ForPath(dest => dest.PayTemplates.DeductionLines.DeductionLinesId, opt => opt.MapFrom(src => src.DeductionId))
                 .ForPath(dest => dest.PayTemplates.SuperMemberships.SuperMembershipsId, opt => opt.MapFrom(src => src.MembershipId))
                 .ForPath(dest => dest.BankAccount.BankAccountId, opt => opt.MapFrom(src => src.BankId))
                  .ForPath(dest => dest.HomeAddress.HomeAddressId, opt => opt.MapFrom(src => src.AddressId))
                   .ForPath(dest => dest.OpenBalances.OpenBalancesId, opt => opt.MapFrom(src => src.OpenBalancesId))
                    .ForPath(dest => dest.PayTemplates.PayTemplatesId, opt => opt.MapFrom(src => src.TemplatesId))
                 .ForMember(dest => dest.IsAuthorizedToLeave, opt => opt.MapFrom(src => src.IsAuthorizedToLeave.ToString()));

            CreateMap<Employee, EmployeeCreation>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => $"{src.Email}"))
               .ForMember(dest => dest.Phonenumber, opt => opt.MapFrom(src => src.Phonenumber))
               .ForMember(dest => dest.Homenumber, opt => opt.MapFrom(src => src.Homenumber))
               .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
               .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
               .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
              
                .ForPath(dest => dest.BankId, opt => opt.MapFrom(src => src.BankAccount.BankAccountId))
                 .ForPath(dest => dest.AddressId, opt => opt.MapFrom(src => src.HomeAddress.HomeAddressId))
                  .ForPath(dest => dest.OpenBalancesId, opt => opt.MapFrom(src => src.OpenBalances.OpenBalancesId))
                   .ForPath(dest => dest.TemplatesId, opt => opt.MapFrom(src => src.PayTemplates.PayTemplatesId))
                .ForMember(dest => dest.IsAuthorizedToLeave, opt => opt.MapFrom(src => src.IsAuthorizedToLeave.ToString()));
        }

    }
}
