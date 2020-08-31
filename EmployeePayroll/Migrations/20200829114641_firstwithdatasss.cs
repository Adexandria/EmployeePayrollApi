using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePayroll.Migrations
{
    public partial class firstwithdatasss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BalanceId",
                table: "Employee",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeductionId",
                table: "Employee",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EarningId",
                table: "Employee",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Employee",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LinesId",
                table: "Employee",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MembershipId",
                table: "Employee",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReId",
                table: "Employee",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SuperId",
                table: "Employee",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DeductionId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EarningId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LinesId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ReId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SuperId",
                table: "Employee");
        }
    }
}
