using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcess.layes.Migrations
{
    /// <inheritdoc />
    public partial class hjllf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorkScheduleCurentWeekDay_workScheduleCurentWeeks_TrainingId",
                table: "EmployeeWorkScheduleCurentWeekDay");

            migrationBuilder.RenameColumn(
                name: "TrainingId",
                table: "EmployeeWorkScheduleCurentWeekDay",
                newName: "WorkScheduleCurentWeekDayId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeWorkScheduleCurentWeekDay_TrainingId",
                table: "EmployeeWorkScheduleCurentWeekDay",
                newName: "IX_EmployeeWorkScheduleCurentWeekDay_WorkScheduleCurentWeekDayId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimestartShift",
                table: "workScheduleCurentWeeks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeEndshifts",
                table: "workScheduleCurentWeeks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorkScheduleCurentWeekDay_workScheduleCurentWeeks_WorkScheduleCurentWeekDayId",
                table: "EmployeeWorkScheduleCurentWeekDay",
                column: "WorkScheduleCurentWeekDayId",
                principalTable: "workScheduleCurentWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorkScheduleCurentWeekDay_workScheduleCurentWeeks_WorkScheduleCurentWeekDayId",
                table: "EmployeeWorkScheduleCurentWeekDay");

            migrationBuilder.RenameColumn(
                name: "WorkScheduleCurentWeekDayId",
                table: "EmployeeWorkScheduleCurentWeekDay",
                newName: "TrainingId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeWorkScheduleCurentWeekDay_WorkScheduleCurentWeekDayId",
                table: "EmployeeWorkScheduleCurentWeekDay",
                newName: "IX_EmployeeWorkScheduleCurentWeekDay_TrainingId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimestartShift",
                table: "workScheduleCurentWeeks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeEndshifts",
                table: "workScheduleCurentWeeks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorkScheduleCurentWeekDay_workScheduleCurentWeeks_TrainingId",
                table: "EmployeeWorkScheduleCurentWeekDay",
                column: "TrainingId",
                principalTable: "workScheduleCurentWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
