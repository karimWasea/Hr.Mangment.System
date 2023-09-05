using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcess.layes.Migrations
{
    /// <inheritdoc />
    public partial class datetimk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Vacations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "EmployeeTrainings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeeTrainings");
        }
    }
}
