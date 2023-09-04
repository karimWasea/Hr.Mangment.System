using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcess.layes.Migrations
{
    /// <inheritdoc />
    public partial class kddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeHistory_AspNetUsers_EmployeeId",
                table: "EmployeeHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeHistory",
                table: "EmployeeHistory");

            migrationBuilder.RenameTable(
                name: "EmployeeHistory",
                newName: "EmployeeHistories");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeHistory_EmployeeId",
                table: "EmployeeHistories",
                newName: "IX_EmployeeHistories_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeHistories",
                table: "EmployeeHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeHistories_AspNetUsers_EmployeeId",
                table: "EmployeeHistories",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeHistories_AspNetUsers_EmployeeId",
                table: "EmployeeHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeHistories",
                table: "EmployeeHistories");

            migrationBuilder.RenameTable(
                name: "EmployeeHistories",
                newName: "EmployeeHistory");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeHistories_EmployeeId",
                table: "EmployeeHistory",
                newName: "IX_EmployeeHistory_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeHistory",
                table: "EmployeeHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeHistory_AspNetUsers_EmployeeId",
                table: "EmployeeHistory",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
