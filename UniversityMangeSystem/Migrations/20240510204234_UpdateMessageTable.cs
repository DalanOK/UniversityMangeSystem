using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityMangeSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c8ad389-e0c9-42c6-bef0-741d3c8790e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1a57570-03e3-44ac-8f05-646e2f52f4cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e901ad35-50b7-47d2-806d-21ff207c47c6");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ced8c110-8e59-4798-bf9e-636479da35db", null, "student", "student" },
                    { "d319244e-90ab-4fe1-850e-61c8224370e3", null, "admin", "admin" },
                    { "e62d5bf8-1c03-4ef2-b3f8-0eea9ba79ec7", null, "teacher", "teacher" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ced8c110-8e59-4798-bf9e-636479da35db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d319244e-90ab-4fe1-850e-61c8224370e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e62d5bf8-1c03-4ef2-b3f8-0eea9ba79ec7");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Messages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c8ad389-e0c9-42c6-bef0-741d3c8790e0", null, "admin", "admin" },
                    { "b1a57570-03e3-44ac-8f05-646e2f52f4cb", null, "teacher", "teacher" },
                    { "e901ad35-50b7-47d2-806d-21ff207c47c6", null, "student", "student" }
                });
        }
    }
}
