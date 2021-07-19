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
                .ForMember(dest => dest.IsAuthorizedToLeave, opt => opt.MapFrom(src => src.IsAuthorizedToLeave.ToString()));



            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.MiddleName} {src.LastName}"))
                 .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.ToString()))
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                 .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()))
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => $"{src.Email }"))
                 .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.HomeAddress))
                 .ForMember(dest => dest.Phonenumber, opt => opt.MapFrom(src => src.Phonenumber))
                 .ForMember(dest => dest.Homenumber, opt => opt.MapFrom(src => src.Homenumber))
                 .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                 .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
                 .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
                 .ForMember(dest => dest.IsAuthorizedToLeave, opt => opt.MapFrom(src => src.IsAuthorizedToLeave.ToString()));



            CreateMap<EmployeeCreation,Employee>()
                 .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
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
                 .ForMember(dest => dest.IsAuthorizedToLeave, opt => opt.MapFrom(src => src.IsAuthorizedToLeave.ToString()));

            CreateMap<Employee, EmployeeCreation>()
                .ForMember(dest => dest.IsAuthorizedToLeave, opt => opt.MapFrom(src => src.IsAuthorizedToLeave.ToString()));
        }

    }
}
