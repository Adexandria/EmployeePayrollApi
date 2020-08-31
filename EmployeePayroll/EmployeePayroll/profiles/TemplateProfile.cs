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
                  .ForMember(dest => dest.PayTemplatesId, opt => opt.MapFrom(src => src.Id))
                   .ForPath(dest => dest.SuperMemberships.SuperMembershipsId, opt => opt.MapFrom(src => src.SuperMemberships.SuperMembershipsId))
                    .ForPath(dest => dest.SuperMemberships.EmployeeNumber, opt => opt.MapFrom(src => src.SuperMemberships.EmployeeNumber))
                  .ForPath(dest => dest.SuperMemberships.SuperFundId, opt => opt.MapFrom(src => src.Id))
                .ForPath(dest => dest.EarningsLines.CalculationType, opt => opt.MapFrom(src => src.EarningsLines.CalculationType))
                   .ForPath(dest => dest.EarningsLines.EarningsLinesId, opt => opt.MapFrom(src => src.EarningsLines.EarningsLinesId))
                      .ForPath(dest => dest.EarningsLines.RatePerUnit, opt => opt.MapFrom(src => src.EarningsLines.RatePerUnit))
                         .ForPath(dest => dest.EarningsLines.NormalNumberOfUnits, opt => opt.MapFrom(src => src.EarningsLines.NormalNumberOfUnits))
                 .ForPath(dest => dest.DeductionLines.DeductionLinesId, opt => opt.MapFrom(src => src.DeductionLines.DeductionLinesId))
                        .ForPath(dest => dest.DeductionLines.CalculationType, opt => opt.MapFrom(src => src.DeductionLines.CalculationType))
                 .ForPath(dest => dest.ReimbursementLines.ReimbursementLinesId, opt => opt.MapFrom(src => src.ReimbursementLines.ReimbursementLinesId))
                   .ForPath(dest => dest.SuperLines.SuperLinesId, opt => opt.MapFrom(src => src.SuperLines.SuperLinesId))
                   .ForPath(dest => dest.SuperLines.MininumMonthlyEarnings, opt => opt.MapFrom(src => src.SuperLines.MininumMonthlyEarnings))
                   .ForPath(dest => dest.SuperLines.LiabilityAccountCode, opt => opt.MapFrom(src => src.SuperLines.LiabilityAccountCode))
                   .ForPath(dest => dest.SuperLines.ExpenseAccountCode, opt => opt.MapFrom(src => src.SuperLines.ExpenseAccountCode))
                   .ForPath(dest => dest.SuperLines.ContributionType, opt => opt.MapFrom(src => src.SuperLines.ContributionType))
                   .ForPath(dest => dest.SuperLines.CalculationType, opt => opt.MapFrom(src => src.SuperLines.CalculationType))
                   .ForPath(dest => dest.LeaveBalances.LeaveBalancesId, opt => opt.MapFrom(src => src.LeaveBalances.LeaveBalancesId))
                    .ForPath(dest => dest.LeaveBalances.NumberOfUnits, opt => opt.MapFrom(src => src.LeaveBalances.NumberOfUnits))
                     .ForPath(dest => dest.LeaveBalances.TypeOfUnits, opt => opt.MapFrom(src => src.LeaveBalances.TypeOfUnits))
                      .ForPath(dest => dest.LeaveBalances.LeaveName, opt => opt.MapFrom(src => src.LeaveBalances.LeaveName));

            CreateMap<Employee, TemplatesCreation>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TemplatesId));
               
            CreateMap<PayTemplates, TemDto>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PayTemplatesId))
                   .ForMember(dest => dest.SuperMemberships, opt => opt.MapFrom(src => src.SuperMemberships))
                      
                .ForMember(dest => dest.EarningsLines, opt => opt.MapFrom(src => src.EarningsLines))
                 .ForMember(dest => dest.DeductionLines, opt => opt.MapFrom(src => src.DeductionLines))
                  .ForMember(dest => dest.ReimbursementLines, opt => opt.MapFrom(src => src.ReimbursementLines))
                   .ForMember(dest => dest.SuperLines, opt => opt.MapFrom(src => src.SuperLines))
                     .ForMember(dest => dest.LeaveBalances, opt => opt.MapFrom(src => src.LeaveBalances)); 
            CreateMap<TemDto, Employee>()
                .ForPath(dest => dest.PayTemplates.EarningsLines.EarningsLinesId, opt => opt.MapFrom(src => src.EarningsLines.EarningsLinesId))
                 .ForPath(dest => dest.PayTemplates.EarningsLines.CalculationType, opt => opt.MapFrom(src => src.EarningsLines.CalculationType))
                  .ForPath(dest => dest.PayTemplates.EarningsLines.NormalNumberOfUnits, opt => opt.MapFrom(src => src.EarningsLines.NormalNumberOfUnits))
                   .ForPath(dest => dest.PayTemplates.EarningsLines.RatePerUnit, opt => opt.MapFrom(src => src.EarningsLines.RatePerUnit))
                    .ForPath(dest => dest.PayTemplates.DeductionLines.DeductionLinesId, opt => opt.MapFrom(src => src.DeductionLines.DeductionLinesId))
                 .ForPath(dest => dest.PayTemplates.DeductionLines.CalculationType, opt => opt.MapFrom(src => src.DeductionLines.CalculationType))
                  .ForPath(dest => dest.PayTemplates.LeaveBalances.LeaveBalancesId, opt => opt.MapFrom(src => src.LeaveBalances.LeaveBalancesId))
                  .ForPath(dest => dest.PayTemplates.LeaveBalances.LeaveName, opt => opt.MapFrom(src => src.LeaveBalances.LeaveName))
                  .ForPath(dest => dest.PayTemplates.LeaveBalances.NumberOfUnits, opt => opt.MapFrom(src => src.LeaveBalances.NumberOfUnits))
                  .ForPath(dest => dest.PayTemplates.LeaveBalances.TypeOfUnits, opt => opt.MapFrom(src => src.LeaveBalances.TypeOfUnits))
                   .ForPath(dest => dest.PayTemplates.SuperLines.CalculationType, opt => opt.MapFrom(src => src.SuperLines.CalculationType))
                   .ForPath(dest => dest.PayTemplates.SuperLines.SuperLinesId, opt => opt.MapFrom(src => src.SuperLines.SuperLinesId))
                   .ForPath(dest => dest.PayTemplates.SuperLines.MininumMonthlyEarnings, opt => opt.MapFrom(src => src.SuperLines.MininumMonthlyEarnings))
                   .ForPath(dest => dest.PayTemplates.SuperLines.ExpenseAccountCode, opt => opt.MapFrom(src => src.SuperLines.ExpenseAccountCode))
                   .ForPath(dest => dest.PayTemplates.SuperLines.ContributionType, opt => opt.MapFrom(src => src.SuperLines.ContributionType))
                   .ForPath(dest => dest.PayTemplates.SuperLines.LiabilityAccountCode,opt => opt.MapFrom(src => src.SuperLines.LiabilityAccountCode))
                    .ForPath(dest => dest.PayTemplates.SuperMemberships.SuperFundId, opt => opt.MapFrom(src => src.SuperMemberships.SuperFundId))
                    .ForPath(dest => dest.PayTemplates.SuperMemberships.SuperMembershipsId, opt => opt.MapFrom(src => src.SuperMemberships.SuperMembershipsId))
                    .ForPath(dest => dest.PayTemplates.SuperMemberships.EmployeeNumber, opt => opt.MapFrom(src => src.SuperMemberships.EmployeeNumber))
                
                      .ForPath(dest => dest.PayTemplates.ReimbursementLines.ReimbursementLinesId, opt => opt.MapFrom(src => src.ReimbursementLines.ReimbursementLinesId));
        }
    }
}
