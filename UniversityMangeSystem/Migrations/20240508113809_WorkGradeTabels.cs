using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityMangeSystem.Migrations
{
    /// <inheritdoc />
    public partial class WorkGradeTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "607f4425-5b0e-44b3-b5d1-3715775e3fa6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77a4ddec-dd24-4fe3-baf1-698b85e77905");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1148097-278e-4c43-a00c-8cae8ae09c80");

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConsultantID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_AspNetUsers_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Works_AspNetUsers_ConsultantID",
                        column: x => x.ConsultantID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GradeValue = table.Column<int>(type: "int", nullable: false),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Works_WorkID",
                        column: x => x.WorkID,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3eaed981-1e49-4cf2-a433-c556dde0bd61", null, "admin", "admin" },
                    { "3f8b1a60-55da-4f22-9276-f15534e7fa14", null, "student", "student" },
                    { "bcc7e2df-99c3-4e62-93d1-fc6d41bc9307", null, "teacher", "teacher" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_WorkID",
                table: "Grades",
                column: "WorkID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_AuthorID",
                table: "Works",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Works_ConsultantID",
                table: "Works",
                column: "ConsultantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Works");

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
                    { "607f4425-5b0e-44b3-b5d1-3715775e3fa6", null, "admin", "admin" },
                    { "77a4ddec-dd24-4fe3-baf1-698b85e77905", null, "teacher", "teacher" },
                    { "d1148097-278e-4c43-a00c-8cae8ae09c80", null, "student", "student" }
                });
        }
    }
}
