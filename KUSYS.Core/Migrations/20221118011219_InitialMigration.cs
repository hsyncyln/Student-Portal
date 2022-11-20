using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KUSYS.Core.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertUserId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Users_InsertUserId",
                        column: x => x.InsertUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertUserId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_InsertUserId",
                        column: x => x.InsertUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName", "UserTypeId" },
                values: new object[,]
                {
                    { 1, "admin", 1 },
                    { 2, "student1", 2 },
                    { 3, "student2", 2 },
                    { 4, "student3", 2 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Code", "InsertDate", "InsertUserId", "IsDeleted", "Name", "UpdateDate", "UpdateUserId" },
                values: new object[,]
                {
                    { 1, "CSI101", new DateTime(2022, 11, 18, 4, 12, 19, 488, DateTimeKind.Local).AddTicks(1525), 1, false, "Introduction to Computer Science", null, 1 },
                    { 2, "CSI102", new DateTime(2022, 11, 18, 4, 12, 19, 488, DateTimeKind.Local).AddTicks(1535), 1, false, "Algorithms", null, 1 },
                    { 3, "MAT101", new DateTime(2022, 11, 18, 4, 12, 19, 488, DateTimeKind.Local).AddTicks(1537), 1, false, "Calculus", null, 1 },
                    { 4, "PHY101", new DateTime(2022, 11, 18, 4, 12, 19, 488, DateTimeKind.Local).AddTicks(1539), 1, false, "Physics", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "FirstName", "InsertDate", "InsertUserId", "IsDeleted", "LastName", "UpdateDate", "UpdateUserId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali", new DateTime(2022, 11, 18, 4, 12, 19, 488, DateTimeKind.Local).AddTicks(1445), 1, false, "Korkmaz", null, null, 2 },
                    { 2, new DateTime(2001, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Selin", new DateTime(2022, 11, 18, 4, 12, 19, 488, DateTimeKind.Local).AddTicks(1474), 1, false, "Kara", null, null, 3 },
                    { 3, new DateTime(1999, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kerem", new DateTime(2022, 11, 18, 4, 12, 19, 488, DateTimeKind.Local).AddTicks(1478), 1, false, "Yıldız", null, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 2 },
                    { 3, 3, 2 },
                    { 4, 2, 2 },
                    { 5, 3, 2 },
                    { 6, 2, 3 },
                    { 7, 3, 3 },
                    { 8, 4, 3 },
                    { 9, 1, 1 },
                    { 10, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InsertUserId",
                table: "Courses",
                column: "InsertUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UpdateUserId",
                table: "Courses",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_InsertUserId",
                table: "Students",
                column: "InsertUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UpdateUserId",
                table: "Students",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
