using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegistrationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegistrationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Workload = table.Column<int>(nullable: false),
                    PrerequisiteId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplines_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplines_Disciplines_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplines_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsDiscipline",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    DisciplineId = table.Column<int>(nullable: false),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    FinalGrade = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsDiscipline", x => new { x.StudentId, x.DisciplineId });
                    table.ForeignKey(
                        name: "FK_StudentsDiscipline_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsDiscipline_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Sistemas de Informação" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "DateBirth", "DateEnd", "DateStart", "LastName", "Name", "Phone", "RegistrationId" },
                values: new object[] { 1, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 1, 27, 9, 14, 46, 214, DateTimeKind.Local).AddTicks(9604), "Kent", "Marta", "33225555", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "DateBirth", "DateEnd", "DateStart", "LastName", "Name", "Phone", "RegistrationId" },
                values: new object[] { 2, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(979), "Isabela", "Paula", "3354288", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "DateBirth", "DateEnd", "DateStart", "LastName", "Name", "Phone", "RegistrationId" },
                values: new object[] { 3, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(1024), "Antonia", "Laura", "55668899", 3 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "DateBirth", "DateEnd", "DateStart", "LastName", "Name", "Phone", "RegistrationId" },
                values: new object[] { 4, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(1029), "Maria", "Luiza", "6565659", 4 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "DateBirth", "DateEnd", "DateStart", "LastName", "Name", "Phone", "RegistrationId" },
                values: new object[] { 5, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(1032), "Machado", "Lucas", "565685415", 5 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "DateBirth", "DateEnd", "DateStart", "LastName", "Name", "Phone", "RegistrationId" },
                values: new object[] { 6, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(1038), "Alvares", "Pedro", "456454545", 6 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "DateBirth", "DateEnd", "DateStart", "LastName", "Name", "Phone", "RegistrationId" },
                values: new object[] { 7, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(1041), "José", "Paulo", "9874512", 7 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "DateEnd", "DateStart", "LastName", "Name", "Phone", "RegistrationId" },
                values: new object[] { 1, true, null, new DateTime(2022, 1, 27, 9, 14, 46, 212, DateTimeKind.Local).AddTicks(5060), "Oliveira", "Lauro", null, 1 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "DateEnd", "DateStart", "LastName", "Name", "Phone", "RegistrationId" },
                values: new object[] { 2, true, null, new DateTime(2022, 1, 27, 9, 14, 46, 213, DateTimeKind.Local).AddTicks(4204), "Soares", "Roberto", null, 2 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "DateEnd", "DateStart", "LastName", "Name", "Phone", "RegistrationId" },
                values: new object[] { 3, true, null, new DateTime(2022, 1, 27, 9, 14, 46, 213, DateTimeKind.Local).AddTicks(4241), "Marconi", "Ronaldo", null, 3 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "DateEnd", "DateStart", "LastName", "Name", "Phone", "RegistrationId" },
                values: new object[] { 4, true, null, new DateTime(2022, 1, 27, 9, 14, 46, 213, DateTimeKind.Local).AddTicks(4243), "Carvalho", "Rodrigo", null, 4 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "DateEnd", "DateStart", "LastName", "Name", "Phone", "RegistrationId" },
                values: new object[] { 5, true, null, new DateTime(2022, 1, 27, 9, 14, 46, 213, DateTimeKind.Local).AddTicks(4244), "Montanha", "Alexandre", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 1, 1, "Matemática", null, 1, 0 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 2, 3, "Matemática", null, 1, 0 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 3, 3, "Física", null, 2, 0 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 4, 1, "Português", null, 3, 0 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 5, 1, "Inglês", null, 4, 0 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 6, 2, "Inglês", null, 4, 0 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 7, 3, "Inglês", null, 4, 0 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 8, 1, "Programação", null, 5, 0 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 9, 2, "Programação", null, 5, 0 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 10, 3, "Programação", null, 5, 0 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 2, 1, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2348), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 4, 5, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2361), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 2, 5, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2353), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 1, 5, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2346), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 7, 4, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2373), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 6, 4, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2369), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 5, 4, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2362), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 4, 4, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2359), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 1, 4, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2324), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 7, 3, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2372), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 5, 5, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2363), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 6, 3, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2366), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 7, 2, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2371), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 6, 2, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2365), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 3, 2, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2355), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 2, 2, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2349), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 1, 2, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(1892), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 7, 1, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2370), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 6, 1, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2364), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 4, 1, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2358), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 3, 1, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2354), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 3, 3, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2356), null });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId", "DateEnd", "DateStart", "FinalGrade" },
                values: new object[] { 7, 5, null, new DateTime(2022, 1, 27, 9, 14, 46, 215, DateTimeKind.Local).AddTicks(2374), null });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_CourseId",
                table: "Disciplines",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_PrerequisiteId",
                table: "Disciplines",
                column: "PrerequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_TeacherId",
                table: "Disciplines",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_CourseId",
                table: "StudentsCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsDiscipline_DisciplineId",
                table: "StudentsDiscipline",
                column: "DisciplineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsCourses");

            migrationBuilder.DropTable(
                name: "StudentsDiscipline");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
