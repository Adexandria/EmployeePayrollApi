using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePayroll.Migrations
{
    public partial class firstwithdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    HomeAddressId = table.Column<Guid>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    PostalCode = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.HomeAddressId);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    BankAccountId = table.Column<Guid>(nullable: false),
                    StatementText = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    Remainder = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.BankAccountId);
                });

            migrationBuilder.CreateTable(
                name: "DeductionLines",
                columns: table => new
                {
                    DeductionLinesId = table.Column<Guid>(nullable: false),
                    CalculationType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeductionLines", x => x.DeductionLinesId);
                });

            migrationBuilder.CreateTable(
                name: "EarningsLines",
                columns: table => new
                {
                    EarningsLinesId = table.Column<Guid>(nullable: false),
                    CalculationType = table.Column<int>(nullable: false),
                    RatePerUnit = table.Column<double>(nullable: false),
                    NormalNumberOfUnits = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarningsLines", x => x.EarningsLinesId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveBalances",
                columns: table => new
                {
                    LeaveBalancesId = table.Column<Guid>(nullable: false),
                    LeaveName = table.Column<string>(nullable: true),
                    NumberOfUnits = table.Column<int>(nullable: false),
                    TypeOfUnits = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveBalances", x => x.LeaveBalancesId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveLines",
                columns: table => new
                {
                    LeaveLinesId = table.Column<Guid>(nullable: false),
                    CalculationType = table.Column<int>(nullable: false),
                    EntitlementFinalPayoutType = table.Column<int>(nullable: false),
                    NumberofUnits = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveLines", x => x.LeaveLinesId);
                });

            migrationBuilder.CreateTable(
                name: "ReimbursementLines",
                columns: table => new
                {
                    ReimbursementLinesId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReimbursementLines", x => x.ReimbursementLinesId);
                });

            migrationBuilder.CreateTable(
                name: "SuperLines",
                columns: table => new
                {
                    SuperLinesId = table.Column<Guid>(nullable: false),
                    ContributionType = table.Column<int>(nullable: false),
                    CalculationType = table.Column<int>(nullable: false),
                    MininumMonthlyEarnings = table.Column<double>(nullable: false),
                    ExpenseAccountCode = table.Column<int>(nullable: false),
                    LiabilityAccountCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperLines", x => x.SuperLinesId);
                });

            migrationBuilder.CreateTable(
                name: "SuperMemberships",
                columns: table => new
                {
                    SuperMembershipsId = table.Column<Guid>(nullable: false),
                    SuperFundId = table.Column<Guid>(nullable: false),
                    EmployeeNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperMemberships", x => x.SuperMembershipsId);
                });

            migrationBuilder.CreateTable(
                name: "OpenBalances",
                columns: table => new
                {
                    OpenBalancesId = table.Column<Guid>(nullable: false),
                    LinesId = table.Column<Guid>(nullable: false),
                    LeaveLinesId = table.Column<Guid>(nullable: true),
                    OpeningBalanceDate = table.Column<DateTimeOffset>(nullable: false),
                    Tax = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenBalances", x => x.OpenBalancesId);
                    table.ForeignKey(
                        name: "FK_OpenBalances_LeaveLines_LeaveLinesId",
                        column: x => x.LeaveLinesId,
                        principalTable: "LeaveLines",
                        principalColumn: "LeaveLinesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayTemplates",
                columns: table => new
                {
                    PayTemplatesId = table.Column<Guid>(nullable: false),
                    EarningsLinesId = table.Column<Guid>(nullable: true),
                    DeductionLinesId = table.Column<Guid>(nullable: true),
                    SuperLinesId = table.Column<Guid>(nullable: true),
                    ReimbursementLinesId = table.Column<Guid>(nullable: true),
                    LeaveLinesId = table.Column<Guid>(nullable: true),
                    LinesId = table.Column<Guid>(nullable: false),
                    ReId = table.Column<Guid>(nullable: false),
                    SuperId = table.Column<Guid>(nullable: false),
                    MembershipId = table.Column<Guid>(nullable: false),
                    Guid = table.Column<Guid>(nullable: false),
                    DeductionId = table.Column<Guid>(nullable: false),
                    EarningId = table.Column<Guid>(nullable: false),
                    SuperMembershipsId = table.Column<Guid>(nullable: true),
                    LeaveBalancesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayTemplates", x => x.PayTemplatesId);
                    table.ForeignKey(
                        name: "FK_PayTemplates_DeductionLines_DeductionLinesId",
                        column: x => x.DeductionLinesId,
                        principalTable: "DeductionLines",
                        principalColumn: "DeductionLinesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayTemplates_EarningsLines_EarningsLinesId",
                        column: x => x.EarningsLinesId,
                        principalTable: "EarningsLines",
                        principalColumn: "EarningsLinesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayTemplates_LeaveBalances_LeaveBalancesId",
                        column: x => x.LeaveBalancesId,
                        principalTable: "LeaveBalances",
                        principalColumn: "LeaveBalancesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayTemplates_LeaveLines_LeaveLinesId",
                        column: x => x.LeaveLinesId,
                        principalTable: "LeaveLines",
                        principalColumn: "LeaveLinesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayTemplates_ReimbursementLines_ReimbursementLinesId",
                        column: x => x.ReimbursementLinesId,
                        principalTable: "ReimbursementLines",
                        principalColumn: "ReimbursementLinesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayTemplates_SuperLines_SuperLinesId",
                        column: x => x.SuperLinesId,
                        principalTable: "SuperLines",
                        principalColumn: "SuperLinesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayTemplates_SuperMemberships_SuperMembershipsId",
                        column: x => x.SuperMembershipsId,
                        principalTable: "SuperMemberships",
                        principalColumn: "SuperMembershipsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(nullable: false),
                    Title = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    Phonenumber = table.Column<string>(nullable: false),
                    Homenumber = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    IsAuthorizedToLeave = table.Column<bool>(nullable: false),
                    BankId = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    OpenBalancesId = table.Column<Guid>(nullable: false),
                    TemplatesId = table.Column<Guid>(nullable: false),
                    PayTemplatesId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "HomeAddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "BankAccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_OpenBalances_OpenBalancesId",
                        column: x => x.OpenBalancesId,
                        principalTable: "OpenBalances",
                        principalColumn: "OpenBalancesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_PayTemplates_PayTemplatesId",
                        column: x => x.PayTemplatesId,
                        principalTable: "PayTemplates",
                        principalColumn: "PayTemplatesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AddressId",
                table: "Employee",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BankId",
                table: "Employee",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_OpenBalancesId",
                table: "Employee",
                column: "OpenBalancesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PayTemplatesId",
                table: "Employee",
                column: "PayTemplatesId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenBalances_LeaveLinesId",
                table: "OpenBalances",
                column: "LeaveLinesId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_DeductionLinesId",
                table: "PayTemplates",
                column: "DeductionLinesId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_EarningsLinesId",
                table: "PayTemplates",
                column: "EarningsLinesId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_LeaveBalancesId",
                table: "PayTemplates",
                column: "LeaveBalancesId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_LeaveLinesId",
                table: "PayTemplates",
                column: "LeaveLinesId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_ReimbursementLinesId",
                table: "PayTemplates",
                column: "ReimbursementLinesId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_SuperLinesId",
                table: "PayTemplates",
                column: "SuperLinesId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_SuperMembershipsId",
                table: "PayTemplates",
                column: "SuperMembershipsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "OpenBalances");

            migrationBuilder.DropTable(
                name: "PayTemplates");

            migrationBuilder.DropTable(
                name: "DeductionLines");

            migrationBuilder.DropTable(
                name: "EarningsLines");

            migrationBuilder.DropTable(
                name: "LeaveBalances");

            migrationBuilder.DropTable(
                name: "LeaveLines");

            migrationBuilder.DropTable(
                name: "ReimbursementLines");

            migrationBuilder.DropTable(
                name: "SuperLines");

            migrationBuilder.DropTable(
                name: "SuperMemberships");
        }
    }
}
