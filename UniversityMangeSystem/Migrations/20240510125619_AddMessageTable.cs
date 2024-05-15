using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityMangeSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SenderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverID",
                        column: x => x.ReceiverID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderID",
                        column: x => x.SenderID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Works_WorkID",
                        column: x => x.WorkID,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c8ad389-e0c9-42c6-bef0-741d3c8790e0", null, "admin", "admin" },
                    { "b1a57570-03e3-44ac-8f05-646e2f52f4cb", null, "teacher", "teacher" },
                    { "e901ad35-50b7-47d2-806d-21ff207c47c6", null, "student", "student" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverID",
                table: "Messages",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderID",
                table: "Messages",
                column: "SenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_WorkID",
                table: "Messages",
                column: "WorkID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

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
    }
}
