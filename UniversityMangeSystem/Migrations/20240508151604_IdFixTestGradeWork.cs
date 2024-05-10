using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityMangeSystem.Migrations
{
    /// <inheritdoc />
    public partial class IdFixTestGradeWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "3cd8238a-0276-45f5-ac85-757d4dd6dbb8", null, "admin", "admin" },
                    { "d989a071-db91-42a0-be4a-fc8ed1c3b8d7", null, "student", "student" },
                    { "ed2cd96f-85c3-46aa-af54-bb3b1a8e96b0", null, "teacher", "teacher" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cd8238a-0276-45f5-ac85-757d4dd6dbb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d989a071-db91-42a0-be4a-fc8ed1c3b8d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed2cd96f-85c3-46aa-af54-bb3b1a8e96b0");

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
    }
}
