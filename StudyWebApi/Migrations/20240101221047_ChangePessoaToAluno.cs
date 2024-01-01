using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangePessoaToAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCurso = table.Column<int>(type: "int", nullable: false),
                    DataIngresso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alunos_Cursos_IDCurso",
                        column: x => x.IDCurso,
                        principalTable: "Cursos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IDCurso",
                table: "Alunos",
                column: "IDCurso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCurso = table.Column<int>(type: "int", nullable: false),
                    DataIngresso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pessoa_Cursos_IDCurso",
                        column: x => x.IDCurso,
                        principalTable: "Cursos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_IDCurso",
                table: "Pessoa",
                column: "IDCurso");
        }
    }
}
