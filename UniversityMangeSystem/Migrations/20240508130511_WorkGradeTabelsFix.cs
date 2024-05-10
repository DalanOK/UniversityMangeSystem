using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityMangeSystem.Migrations
{
    /// <inheritdoc />
    public partial class WorkGradeTabelsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3eaed981-1e49-4cf2-a433-c556dde0bd61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f8b1a60-55da-4f22-9276-f15534e7fa14");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcc7e2df-99c3-4e62-93d1-fc6d41bc9307");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "3eaed981-1e49-4cf2-a433-c556dde0bd61", null, "admin", "admin" },
                    { "3f8b1a60-55da-4f22-9276-f15534e7fa14", null, "student", "student" },
                    { "bcc7e2df-99c3-4e62-93d1-fc6d41bc9307", null, "teacher", "teacher" }
                });
        }
    }
}
