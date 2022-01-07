using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
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
                    DisciplineId = table.Column<int>(nullable: false)
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
                table: "Students",
                columns: new[] { "Id", "LastName", "Name", "Phone" },
                values: new object[] { 1, "Kent", "Marta", "33225555" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "LastName", "Name", "Phone" },
                values: new object[] { 2, "Isabela", "Paula", "3354288" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "LastName", "Name", "Phone" },
                values: new object[] { 3, "Antonia", "Laura", "55668899" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "LastName", "Name", "Phone" },
                values: new object[] { 4, "Maria", "Luiza", "6565659" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "LastName", "Name", "Phone" },
                values: new object[] { 5, "Machado", "Lucas", "565685415" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "LastName", "Name", "Phone" },
                values: new object[] { 6, "Alvares", "Pedro", "456454545" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "LastName", "Name", "Phone" },
                values: new object[] { 7, "José", "Paulo", "9874512" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Lauro" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Roberto" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Ronaldo" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Rodrigo" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Alexandre" });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 1, "Matemática", 1 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 2, "Física", 2 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 3, "Português", 3 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 4, "Inglês", 4 });

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 5, "Programação", 5 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "StudentsDiscipline",
                columns: new[] { "StudentId", "DisciplineId" },
                values: new object[] { 7, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_TeacherId",
                table: "Disciplines",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsDiscipline_DisciplineId",
                table: "StudentsDiscipline",
                column: "DisciplineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsDiscipline");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
