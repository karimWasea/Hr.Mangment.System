using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcess.layes.Migrations
{
    /// <inheritdoc />
    public partial class k : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MamthName",
                table: "EmployeeHistory");

            migrationBuilder.AddColumn<DateTime>(
                name: "Month",
                table: "EmployeeHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "EmployeeDevices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "EmployeeHistory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeeDevices");

            migrationBuilder.AddColumn<string>(
                name: "MamthName",
                table: "EmployeeHistory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
