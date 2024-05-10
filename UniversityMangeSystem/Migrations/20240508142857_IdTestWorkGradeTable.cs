using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityMangeSystem.Migrations
{
    /// <inheritdoc />
    public partial class IdTestWorkGradeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3281b7f0-3d44-428a-a11c-f952c0037a5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a46f624-d7a7-414c-8f16-63ff132a24ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9be625f7-92f0-44fb-8cf9-6b451515eb60");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c8ee1f99-62e7-4dd6-9812-d428cbd87f53", null, "student", "student" },
                    { "c955db9f-f5e9-43ff-8869-7dd67f4d3d4e", null, "teacher", "teacher" },
                    { "e5a51022-7dcd-4f7a-8f5d-0c24057e3672", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8ee1f99-62e7-4dd6-9812-d428cbd87f53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c955db9f-f5e9-43ff-8869-7dd67f4d3d4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5a51022-7dcd-4f7a-8f5d-0c24057e3672");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3281b7f0-3d44-428a-a11c-f952c0037a5e", null, "student", "student" },
                    { "9a46f624-d7a7-414c-8f16-63ff132a24ee", null, "admin", "admin" },
                    { "9be625f7-92f0-44fb-8cf9-6b451515eb60", null, "teacher", "teacher" }
                });
        }
    }
}
