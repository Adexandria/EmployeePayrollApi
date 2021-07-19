using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePayroll.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeductionLines",
                columns: table => new
                {
                    DeductionLineId = table.Column<Guid>(nullable: false),
                    CalculationType = table.Column<int>(nullable: false),
                    PayTemplateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeductionLines", x => x.DeductionLineId);
                });

            migrationBuilder.CreateTable(
                name: "EarningsLines",
                columns: table => new
                {
                    EarningsLineId = table.Column<Guid>(nullable: false),
                    CalculationType = table.Column<int>(nullable: false),
                    RatePerUnit = table.Column<double>(nullable: false),
                    NormalNumberOfUnits = table.Column<double>(nullable: false),
                    PayTemplateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarningsLines", x => x.EarningsLineId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveBalances",
                columns: table => new
                {
                    LeaveBalanceId = table.Column<Guid>(nullable: false),
                    LeaveName = table.Column<string>(nullable: true),
                    NumberOfUnits = table.Column<int>(nullable: false),
                    TypeOfUnits = table.Column<int>(nullable: false),
                    PayTemplateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveBalances", x => x.LeaveBalanceId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveLines",
                columns: table => new
                {
                    LeaveLineId = table.Column<Guid>(nullable: false),
                    CalculationType = table.Column<int>(nullable: false),
                    EntitlementFinalPayoutType = table.Column<int>(nullable: false),
                    NumberofUnits = table.Column<string>(nullable: true),
                    OpenbalanceId = table.Column<Guid>(nullable: false),
                    PayTemplateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveLines", x => x.LeaveLineId);
                });

            migrationBuilder.CreateTable(
                name: "ReimbursementLines",
                columns: table => new
                {
                    ReimbursementLineId = table.Column<Guid>(nullable: false),
                    PayTemplateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReimbursementLines", x => x.ReimbursementLineId);
                });

            migrationBuilder.CreateTable(
                name: "SuperLines",
                columns: table => new
                {
                    SuperLineId = table.Column<Guid>(nullable: false),
                    ContributionType = table.Column<int>(nullable: false),
                    CalculationType = table.Column<int>(nullable: false),
                    MininumMonthlyEarnings = table.Column<double>(nullable: false),
                    ExpenseAccountCode = table.Column<int>(nullable: false),
                    LiabilityAccountCode = table.Column<int>(nullable: false),
                    PayTemplateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperLines", x => x.SuperLineId);
                });

            migrationBuilder.CreateTable(
                name: "SuperMemberships",
                columns: table => new
                {
                    SuperMembershipId = table.Column<Guid>(nullable: false),
                    SuperFundId = table.Column<Guid>(nullable: false),
                    EmployeeNumber = table.Column<int>(nullable: false),
                    PayTemplateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperMemberships", x => x.SuperMembershipId);
                });

            migrationBuilder.CreateTable(
                name: "PayTemplates",
                columns: table => new
                {
                    PayTemplateId = table.Column<Guid>(nullable: false),
                    EarningsLineId = table.Column<Guid>(nullable: true),
                    DeductionLineId = table.Column<Guid>(nullable: true),
                    SuperLineId = table.Column<Guid>(nullable: true),
                    ReimbursementLineId = table.Column<Guid>(nullable: true),
                    LeaveLineId = table.Column<Guid>(nullable: true),
                    SuperMembershipId = table.Column<Guid>(nullable: true),
                    LeaveBalanceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayTemplates", x => x.PayTemplateId);
                    table.ForeignKey(
                        name: "FK_PayTemplates_DeductionLines_DeductionLineId",
                        column: x => x.DeductionLineId,
                        principalTable: "DeductionLines",
                        principalColumn: "DeductionLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayTemplates_EarningsLines_EarningsLineId",
                        column: x => x.EarningsLineId,
                        principalTable: "EarningsLines",
                        principalColumn: "EarningsLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayTemplates_LeaveBalances_LeaveBalanceId",
                        column: x => x.LeaveBalanceId,
                        principalTable: "LeaveBalances",
                        principalColumn: "LeaveBalanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayTemplates_LeaveLines_LeaveLineId",
                        column: x => x.LeaveLineId,
                        principalTable: "LeaveLines",
                        principalColumn: "LeaveLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayTemplates_ReimbursementLines_ReimbursementLineId",
                        column: x => x.ReimbursementLineId,
                        principalTable: "ReimbursementLines",
                        principalColumn: "ReimbursementLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayTemplates_SuperLines_SuperLineId",
                        column: x => x.SuperLineId,
                        principalTable: "SuperLines",
                        principalColumn: "SuperLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayTemplates_SuperMemberships_SuperMembershipId",
                        column: x => x.SuperMembershipId,
                        principalTable: "SuperMemberships",
                        principalColumn: "SuperMembershipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(nullable: false),
                    Title = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    Phonenumber = table.Column<string>(nullable: true),
                    Homenumber = table.Column<string>(nullable: true),
                    IsAuthorizedToLeave = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    PayTemplateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                   
                });

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
                    Country = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.HomeAddressId);
                    table.ForeignKey(
                        name: "FK_Address_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    BankAccountId = table.Column<Guid>(nullable: false),
                    StatementText = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    Remainder = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.BankAccountId);
                    table.ForeignKey(
                        name: "FK_Bank_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenBalances",
                columns: table => new
                {
                    OpenBalanceId = table.Column<Guid>(nullable: false),
                    LeaveLineId = table.Column<Guid>(nullable: true),
                    OpeningBalanceDate = table.Column<DateTimeOffset>(nullable: false),
                    Tax = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenBalances", x => x.OpenBalanceId);
                    table.ForeignKey(
                        name: "FK_OpenBalances_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpenBalances_LeaveLines_LeaveLineId",
                        column: x => x.LeaveLineId,
                        principalTable: "LeaveLines",
                        principalColumn: "LeaveLineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmployeeId",
                table: "Address",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bank_EmployeeId",
                table: "Bank",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PayTemplateId",
                table: "Employee",
                column: "PayTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenBalances_EmployeeId",
                table: "OpenBalances",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenBalances_LeaveLineId",
                table: "OpenBalances",
                column: "LeaveLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_DeductionLineId",
                table: "PayTemplates",
                column: "DeductionLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_EarningsLineId",
                table: "PayTemplates",
                column: "EarningsLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_LeaveBalanceId",
                table: "PayTemplates",
                column: "LeaveBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_LeaveLineId",
                table: "PayTemplates",
                column: "LeaveLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_ReimbursementLineId",
                table: "PayTemplates",
                column: "ReimbursementLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_SuperLineId",
                table: "PayTemplates",
                column: "SuperLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PayTemplates_SuperMembershipId",
                table: "PayTemplates",
                column: "SuperMembershipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "OpenBalances");

            migrationBuilder.DropTable(
                name: "Employee");

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
