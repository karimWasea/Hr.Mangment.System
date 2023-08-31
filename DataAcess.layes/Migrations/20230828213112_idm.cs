using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcess.layes.Migrations
{
    /// <inheritdoc />
    public partial class idm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "VacationId",
                table: "Vacations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                table: "Trainings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TimeShiftId",
                table: "TimeShifts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SalaryTransactionId",
                table: "SalaryTransactions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmployeeTrainingId",
                table: "EmployeeTrainings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmployeeHistoryId",
                table: "EmployeeHistory",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmployeeDeviceId",
                table: "EmployeeDevices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "Devices",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vacations",
                newName: "VacationId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Trainings",
                newName: "TrainingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TimeShifts",
                newName: "TimeShiftId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SalaryTransactions",
                newName: "SalaryTransactionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmployeeTrainings",
                newName: "EmployeeTrainingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmployeeHistory",
                newName: "EmployeeHistoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmployeeDevices",
                newName: "EmployeeDeviceId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Devices",
                newName: "DeviceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }
    }
}
