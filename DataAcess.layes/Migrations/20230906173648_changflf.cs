using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcess.layes.Migrations
{
    /// <inheritdoc />
    public partial class changflf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimestartDate",
                table: "workScheduleCurentWeeks",
                newName: "TimestartShift");

            migrationBuilder.RenameColumn(
                name: "Endshifts",
                table: "workScheduleCurentWeeks",
                newName: "TimeEndshifts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimestartShift",
                table: "workScheduleCurentWeeks",
                newName: "TimestartDate");

            migrationBuilder.RenameColumn(
                name: "TimeEndshifts",
                table: "workScheduleCurentWeeks",
                newName: "Endshifts");
        }
    }
}
