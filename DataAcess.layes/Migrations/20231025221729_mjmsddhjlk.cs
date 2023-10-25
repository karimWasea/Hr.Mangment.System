using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAcess.layes.Migrations
{
    /// <inheritdoc />
    public partial class mjmsddhjlk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f53b9e8-aa54-4e54-bee1-cdd20ff5ca0e", null, "Admin", "ADMIN" },
                    { "49d0cad2-1046-4d82-af98-86eea4f8a713", null, "SuperAdmin", "SUPERADMIN" },
                    { "80cb8b1a-64fd-45cb-98cb-846d2113371f", null, "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "BirthDate", "Bouns", "ConcurrencyStamp", "ContructUrl", "DepartmentId", "Email", "EmailConfirmed", "Gender", "HirangDate", "ImgUrl", "IsDeleted", "JobTitle", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6e384d3b-7775-4e4c-90b7-a5db563deb9f", 0, "", null, null, "4111ba2b-055e-4bc8-a788-c154c0e9571d", null, null, "SuperAdmin1995@gmail.com", true, 0, null, null, 0, null, false, null, "SuperAdmin1995@gmail.com", "superAdmin", "AQAAAAIAAYagAAAAEC3yXRhVl4k1pfAaAe5tI9f6pq6nznvYsqGP4QDdqxxthSD65o3K7+KS8YoFfLjd+Q==", null, false, 1000.0, "99d5ccfe-af78-4d7f-a0ea-7ca971451d96", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "49d0cad2-1046-4d82-af98-86eea4f8a713", "6e384d3b-7775-4e4c-90b7-a5db563deb9f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f53b9e8-aa54-4e54-bee1-cdd20ff5ca0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80cb8b1a-64fd-45cb-98cb-846d2113371f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "49d0cad2-1046-4d82-af98-86eea4f8a713", "6e384d3b-7775-4e4c-90b7-a5db563deb9f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49d0cad2-1046-4d82-af98-86eea4f8a713");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e384d3b-7775-4e4c-90b7-a5db563deb9f");
        }
    }
}
