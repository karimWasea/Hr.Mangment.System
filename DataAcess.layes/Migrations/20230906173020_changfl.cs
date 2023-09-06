using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcess.layes.Migrations
{
    /// <inheritdoc />
    public partial class changfl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workScheduleCurentWeeks_AspNetUsers_EmployeeId",
                table: "workScheduleCurentWeeks");

            migrationBuilder.DropIndex(
                name: "IX_workScheduleCurentWeeks_EmployeeId",
                table: "workScheduleCurentWeeks");

            migrationBuilder.DropColumn(
                name: "shiftStuTework",
                table: "workScheduleCurentWeeks");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "workScheduleCurentWeeks",
                newName: "TimestartDate");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "workScheduleCurentWeeks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Endshifts",
                table: "workScheduleCurentWeeks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShiftName",
                table: "workScheduleCurentWeeks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EmployeeWorkScheduleCurentWeekDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeShiftId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWorkScheduleCurentWeekDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkScheduleCurentWeekDay_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeWorkScheduleCurentWeekDay_workScheduleCurentWeeks_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "workScheduleCurentWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkScheduleCurentWeekDay_EmployeeId",
                table: "EmployeeWorkScheduleCurentWeekDay",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkScheduleCurentWeekDay_TrainingId",
                table: "EmployeeWorkScheduleCurentWeekDay",
                column: "TrainingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeWorkScheduleCurentWeekDay");

            migrationBuilder.DropColumn(
                name: "Endshifts",
                table: "workScheduleCurentWeeks");

            migrationBuilder.DropColumn(
                name: "ShiftName",
                table: "workScheduleCurentWeeks");

            migrationBuilder.RenameColumn(
                name: "TimestartDate",
                table: "workScheduleCurentWeeks",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "workScheduleCurentWeeks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "shiftStuTework",
                table: "workScheduleCurentWeeks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_workScheduleCurentWeeks_EmployeeId",
                table: "workScheduleCurentWeeks",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_workScheduleCurentWeeks_AspNetUsers_EmployeeId",
                table: "workScheduleCurentWeeks",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
