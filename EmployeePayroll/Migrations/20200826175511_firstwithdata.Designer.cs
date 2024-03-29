﻿// <auto-generated />
using System;
using EmployeePayroll.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeePayroll.Migrations
{
    [DbContext(typeof(DataDb))]
    [Migration("20200826175511_firstwithdata")]
    partial class firstwithdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeePayroll.Entities.Address", b =>
                {
                    b.Property<Guid>("HomeAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HomeAddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.Bank", b =>
                {
                    b.Property<Guid>("BankAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Remainder")
                        .HasColumnType("bit");

                    b.Property<string>("StatementText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BankAccountId");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.DeductionLines", b =>
                {
                    b.Property<Guid>("DeductionLinesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CalculationType")
                        .HasColumnType("int");

                    b.HasKey("DeductionLinesId");

                    b.ToTable("DeductionLines");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.EarningsLines", b =>
                {
                    b.Property<Guid>("EarningsLinesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CalculationType")
                        .HasColumnType("int");

                    b.Property<double>("NormalNumberOfUnits")
                        .HasColumnType("float");

                    b.Property<double>("RatePerUnit")
                        .HasColumnType("float");

                    b.HasKey("EarningsLinesId");

                    b.ToTable("EarningsLines");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BankId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateOfBirth")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Homenumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAuthorizedToLeave")
                        .HasColumnType("bit");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<Guid>("OpenBalancesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PayTemplatesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TemplatesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Title")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("EmployeeId");

                    b.HasIndex("AddressId");

                    b.HasIndex("BankId");

                    b.HasIndex("OpenBalancesId");

                    b.HasIndex("PayTemplatesId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.LeaveBalances", b =>
                {
                    b.Property<Guid>("LeaveBalancesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LeaveName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfUnits")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfUnits")
                        .HasColumnType("int");

                    b.HasKey("LeaveBalancesId");

                    b.ToTable("LeaveBalances");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.LeaveLines", b =>
                {
                    b.Property<Guid>("LeaveLinesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CalculationType")
                        .HasColumnType("int");

                    b.Property<int>("EntitlementFinalPayoutType")
                        .HasColumnType("int");

                    b.Property<double>("NumberofUnits")
                        .HasColumnType("float");

                    b.HasKey("LeaveLinesId");

                    b.ToTable("LeaveLines");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.OpenBalances", b =>
                {
                    b.Property<Guid>("OpenBalancesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LeaveLinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("OpeningBalanceDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Tax")
                        .HasColumnType("int");

                    b.HasKey("OpenBalancesId");

                    b.HasIndex("LeaveLinesId");

                    b.ToTable("OpenBalances");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.PayTemplates", b =>
                {
                    b.Property<Guid>("PayTemplatesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeductionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeductionLinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EarningId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EarningsLinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LeaveBalancesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LeaveLinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MembershipId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ReimbursementLinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SuperId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SuperLinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SuperMembershipsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PayTemplatesId");

                    b.HasIndex("DeductionLinesId");

                    b.HasIndex("EarningsLinesId");

                    b.HasIndex("LeaveBalancesId");

                    b.HasIndex("LeaveLinesId");

                    b.HasIndex("ReimbursementLinesId");

                    b.HasIndex("SuperLinesId");

                    b.HasIndex("SuperMembershipsId");

                    b.ToTable("PayTemplates");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.ReimbursementLines", b =>
                {
                    b.Property<Guid>("ReimbursementLinesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReimbursementLinesId");

                    b.ToTable("ReimbursementLines");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.SuperLines", b =>
                {
                    b.Property<Guid>("SuperLinesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CalculationType")
                        .HasColumnType("int");

                    b.Property<int>("ContributionType")
                        .HasColumnType("int");

                    b.Property<int>("ExpenseAccountCode")
                        .HasColumnType("int");

                    b.Property<int>("LiabilityAccountCode")
                        .HasColumnType("int");

                    b.Property<double>("MininumMonthlyEarnings")
                        .HasColumnType("float");

                    b.HasKey("SuperLinesId");

                    b.ToTable("SuperLines");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.SuperMemberships", b =>
                {
                    b.Property<Guid>("SuperMembershipsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("SuperFundId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SuperMembershipsId");

                    b.ToTable("SuperMemberships");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.Employee", b =>
                {
                    b.HasOne("EmployeePayroll.Entities.Address", "HomeAddress")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeePayroll.Entities.Bank", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeePayroll.Entities.OpenBalances", "OpenBalances")
                        .WithMany()
                        .HasForeignKey("OpenBalancesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeePayroll.Entities.PayTemplates", "PayTemplates")
                        .WithMany()
                        .HasForeignKey("PayTemplatesId");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.OpenBalances", b =>
                {
                    b.HasOne("EmployeePayroll.Entities.LeaveLines", "LeaveLines")
                        .WithMany()
                        .HasForeignKey("LeaveLinesId");
                });

            modelBuilder.Entity("EmployeePayroll.Entities.PayTemplates", b =>
                {
                    b.HasOne("EmployeePayroll.Entities.DeductionLines", "DeductionLines")
                        .WithMany()
                        .HasForeignKey("DeductionLinesId");

                    b.HasOne("EmployeePayroll.Entities.EarningsLines", "EarningsLines")
                        .WithMany()
                        .HasForeignKey("EarningsLinesId");

                    b.HasOne("EmployeePayroll.Entities.LeaveBalances", "LeaveBalances")
                        .WithMany()
                        .HasForeignKey("LeaveBalancesId");

                    b.HasOne("EmployeePayroll.Entities.LeaveLines", "LeaveLines")
                        .WithMany()
                        .HasForeignKey("LeaveLinesId");

                    b.HasOne("EmployeePayroll.Entities.ReimbursementLines", "ReimbursementLines")
                        .WithMany()
                        .HasForeignKey("ReimbursementLinesId");

                    b.HasOne("EmployeePayroll.Entities.SuperLines", "SuperLines")
                        .WithMany()
                        .HasForeignKey("SuperLinesId");

                    b.HasOne("EmployeePayroll.Entities.SuperMemberships", "SuperMemberships")
                        .WithMany()
                        .HasForeignKey("SuperMembershipsId");
                });
#pragma warning restore 612, 618
        }
    }
}
