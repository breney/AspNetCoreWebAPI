using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchool.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateUpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registration = table.Column<int>(type: "int", nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registration = table.Column<int>(type: "int", nullable: false),
                    DateTimeBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    WorkLoad = table.Column<int>(type: "int", nullable: false),
                    PreRequirementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discipline_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discipline_Discipline_PreRequirementId",
                        column: x => x.PreRequirementId,
                        principalTable: "Discipline",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Discipline_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineStudent",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineStudent", x => new { x.StudentId, x.DisciplineId });
                    table.ForeignKey(
                        name: "FK_DisciplineStudent_Discipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tecnologia de Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciencia de Computação" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Active", "DateBirth", "DateTimeBegin", "DateTimeEnd", "Name", "Registration", "Surname", "Telephone" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3445), null, "Marta", 1, "Kent", "33225555" },
                    { 2, true, new DateTime(2005, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3515), null, "Paula", 2, "Isabela", "3354288" },
                    { 3, true, new DateTime(2005, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3520), null, "Laura", 3, "Antonia", "55668899" },
                    { 4, true, new DateTime(2005, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3524), null, "Luiza", 4, "Maria", "6565659" },
                    { 5, true, new DateTime(2005, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3527), null, "Lucas", 5, "Machado", "565685415" },
                    { 6, true, new DateTime(2005, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3531), null, "Pedro", 6, "Alvares", "456454545" },
                    { 7, true, new DateTime(2005, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3535), null, "Paulo", 7, "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Active", "DateTimeBegin", "DateTimeEnd", "Name", "Registration", "Surname" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3355), null, "Lauro", 1, "Oliveira" },
                    { 2, true, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3390), null, "Roberto", 2, "Soares" },
                    { 3, true, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3392), null, "Ronaldo", 3, "Cristiano" },
                    { 4, true, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3393), null, "Rodrigo", 4, "Carvalho" },
                    { 5, true, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3394), null, "Alexandre", 5, "Montana" }
                });

            migrationBuilder.InsertData(
                table: "Discipline",
                columns: new[] { "Id", "CourseId", "Name", "PreRequirementId", "TeacherId", "WorkLoad" },
                values: new object[,]
                {
                    { 1, 1, "Matemática", null, 1, 0 },
                    { 2, 3, "Matemática", null, 1, 0 },
                    { 3, 3, "Física", null, 2, 0 },
                    { 4, 1, "Português", null, 3, 0 },
                    { 5, 1, "Inglês", null, 4, 0 },
                    { 6, 2, "Inglês", null, 4, 0 },
                    { 7, 3, "Inglês", null, 2, 0 },
                    { 8, 1, "Programação", null, 5, 0 },
                    { 9, 2, "Programação", null, 5, 0 },
                    { 10, 3, "Programação", null, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "DisciplineStudent",
                columns: new[] { "DisciplineId", "StudentId", "DateBegin", "DateEnd", "Grade" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3551), null, null },
                    { 4, 1, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3554), null, null },
                    { 5, 1, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3555), null, null },
                    { 1, 2, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3556), null, null },
                    { 2, 2, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3558), null, null },
                    { 5, 2, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3559), null, null },
                    { 1, 3, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3560), null, null },
                    { 2, 3, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3563), null, null },
                    { 3, 3, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3564), null, null },
                    { 1, 4, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3565), null, null },
                    { 4, 4, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3566), null, null },
                    { 5, 4, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3568), null, null },
                    { 4, 5, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3569), null, null },
                    { 5, 5, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3597), null, null },
                    { 1, 6, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3600), null, null },
                    { 2, 6, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3601), null, null },
                    { 3, 6, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3602), null, null },
                    { 4, 6, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3604), null, null },
                    { 1, 7, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3605), null, null },
                    { 2, 7, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3606), null, null },
                    { 3, 7, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3607), null, null },
                    { 4, 7, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3609), null, null },
                    { 5, 7, new DateTime(2023, 2, 13, 10, 43, 11, 463, DateTimeKind.Local).AddTicks(3610), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_CourseId",
                table: "CourseStudent",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_CourseId",
                table: "Discipline",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_PreRequirementId",
                table: "Discipline",
                column: "PreRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_TeacherId",
                table: "Discipline",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineStudent_DisciplineId",
                table: "DisciplineStudent",
                column: "DisciplineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "DisciplineStudent");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
