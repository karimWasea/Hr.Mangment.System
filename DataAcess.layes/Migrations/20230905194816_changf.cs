using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcess.layes.Migrations
{
    /// <inheritdoc />
    public partial class changf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "workScheduleCurentWeeks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "workScheduleCurentWeeks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Trainings");
        }
    }
}
